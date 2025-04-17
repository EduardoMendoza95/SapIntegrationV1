using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wee.SapIntegration.Application.Features.Interfaces;
using Wee.SapIntegration.Core.Entities;
using Microsoft.Extensions.Configuration;
using Wee.SapIntegration.Infrastructure.Data;
using MongoDB.Driver;
using Wee.SapIntegration.Core.Entities;
using Wee.SapIntegration.Application.Features.AltaCliente.Dtos;

public class AltaClienteService : IAltaClienteService
{
    private readonly HttpClient _http;
    private readonly IClientePayloadBuilder _builder;
    private readonly ITokenService _tokenService;
    private readonly IMongoCollection<AltaClienteLog> _logCollection;
    private readonly AppDbContext _context;

    public AltaClienteService(HttpClient http, IClientePayloadBuilder builder, ITokenService tokenService, IConfiguration config, AppDbContext context)
    {
        _http = http;
        _builder = builder;
        _tokenService = tokenService;
        var mongoClient = new MongoClient(config["Mongo:ConnectionString"]);
        var mongoDatabase = mongoClient.GetDatabase(config["Mongo:Database"]);
        _logCollection = mongoDatabase.GetCollection<AltaClienteLog>("LogsSAP");
        _context = context;
    }

    public async Task<AltaClienteResponseDto> EnviarClienteASAPAsync(Guid idCotizacion)
    {
        try
        {
            var token = await _tokenService.ObtenerTokenAsync();
            var payload = await _builder.BuildPayloadAsync(idCotizacion);
            var url = _builder.GetEndpointUrl();
            var method = _builder.GetHttpMethod();

            var request = new HttpRequestMessage(method, url)
            {
                Content = JsonContent.Create(payload)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var response = await _http.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Mongo Log
            await _logCollection.InsertOneAsync(new AltaClienteLog
            {
                Paso = "alta_cliente",
                Endpoint = url,
                Payload = payload,
                Response = responseBody,
                Status = response.StatusCode.ToString(),
                IdCotizacion = idCotizacion.ToString(),
                EsError = !response.IsSuccessStatusCode
            });

            // SQL Log si es exitoso
            if (response.IsSuccessStatusCode)
            {
                _context.RegistroCliente.Add(new RegistroCliente
                {
                    idRegistro = Guid.NewGuid(),
                    IdCotizacion = idCotizacion,
                    Payload = JsonSerializer.Serialize(payload),
                    ResponseJSON = responseBody,
                    xDateInsert = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            return new AltaClienteResponseDto
            {
                Exitoso = response.IsSuccessStatusCode,
                Mensaje = response.IsSuccessStatusCode ? "Cliente creado correctamente en SAP." : "Error en SAP",
                ResponseRaw = responseBody
            };
        }
        catch (Exception ex)
        {
            return new AltaClienteResponseDto
            {
                Exitoso = false,
                Mensaje = $"Error: {ex.Message}"
            };
        }
    }
}
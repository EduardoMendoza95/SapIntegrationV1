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


public class ChopoAltaClientePayloadBuilder : IClientePayloadBuilder
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;

    public ChopoAltaClientePayloadBuilder(IConfiguration config, AppDbContext context)
    {
        _config = config;
        _context = context;
    }

    public async Task<Dictionary<string, object>> BuildPayloadAsync(Guid idCotizacion)
    {
        var cliente = await _context.ChopoRequest.FirstOrDefaultAsync(x => x.IdCotizacion == idCotizacion);
        if (cliente == null)
            throw new Exception("Cliente no encontrado");

     var payload = new Dictionary<string, object?>
    {
        ["marca"] = cliente.Marca,
        ["nombreCliente"] = cliente.NombreCliente,
        ["nombreCliente2"] = cliente.NombreCliente2,
        ["nombreCliente3"] = cliente.NombreCliente3,
        ["nombreCliente4"] = cliente.NombreCliente4,
        ["rfc"] = cliente.RFC,
        ["calle1"] = cliente.Calle1,
        ["calle2"] = cliente.Calle2,
        ["numeroExterior"] = cliente.NoExterior,
        ["numeroInterior"] = cliente.NoInterior,
        ["colonia"] = cliente.d_asenta,
        ["codigoPostal"] = cliente.d_codigo,
        ["delegacionMunicipio"] = cliente.D_mnpio,
        ["estado"] = cliente.AbrevSAP,
        ["pais"] = cliente.nom2,
        ["telefono1"] = cliente.Telefono,
        ["telefono2"] = cliente.Celular,
        ["correo"] = cliente.email,
        ["personaFisica"] = cliente.codTipoPersona.ToString(),
        ["lineaTransmDa"] = cliente.NombreContacto,
        ["telebox"] = cliente.CargoPuesto,
        ["telefono3"] = cliente.Telefono,
        ["telefonoMovil"] = cliente.Celular,
        ["corEl"] = cliente.email,
        ["orgVtas"] = cliente.OrgVtas,
        ["canal"] = cliente.Canal,
        ["sector"] = cliente.Sector,
        ["nomEjeVta"] = cliente.NombreEjecutivo,
        ["analistaFact"] = "",
        ["gpoTesoreria"] = cliente.GpoTesoreria,
        ["nomCconv"] = cliente.NomConv,
        ["numCliente"] = "",
        ["condPag"] = cliente.CondPag,
        ["atributo3"] = "",
        ["grpCliente1"] = "",
        ["grpCliente2"] = cliente.GrpCliente2,
        ["grpCliente3"] = cliente.GrpCliente3,
        ["grpCliente4"] = cliente.GrpCliente4,
        ["grpCliente5"] = cliente.GrpCliente5,
        ["usoCFDI"] = "03",
        ["direccionPortal"] = "",
        ["regimenFiscal"] = cliente.codRegimenFiscal
    };

        return payload
            .Where(kv => kv.Value is string str ? !string.IsNullOrWhiteSpace(str) : kv.Value != null)
            .ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    public string GetEndpointUrl() => _config["SapApi:AltaClienteUrl"];

    public HttpMethod GetHttpMethod() => HttpMethod.Post;
}
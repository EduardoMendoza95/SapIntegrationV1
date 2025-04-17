using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Wee.SapIntegration.Application.Features.Interfaces;
using Wee.SapIntegration.Core.Entities;
using Wee.SapIntegration.Application.Features.Autenticacion.Dtos;

namespace Wee.SapIntegration.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMongoCollection<TokenLog> _tokens;
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public TokenService(IConfiguration config, HttpClient http)
        {
            _config = config;
            _http = http;

            var client = new MongoClient(_config["Mongo:ConnectionString"]);
            var db = client.GetDatabase(_config["Mongo:Database"]);
            _tokens = db.GetCollection<TokenLog>(_config["Mongo:TokenCollection"]);
        }

        public async Task<TokenResponseDto> ObtenerTokenAsync()
        {
            var base64 = _config["SapApi:TokenAuthorization"];

            var tokenExistente = await _tokens
                .Find(t => t.AuthorizationBase64 == base64)
                .SortByDescending(t => t.FechaGeneracion)
                .FirstOrDefaultAsync();

            if (tokenExistente != null && tokenExistente.FechaExpiracion > DateTime.UtcNow)
            {
                return new TokenResponseDto
                {
                    AccessToken = tokenExistente.AccessToken,
                    Expiration = tokenExistente.FechaExpiracion,
                    TokenType = "Bearer"
                };
            }

            var request = new HttpRequestMessage(HttpMethod.Post, _config["SapApi:TokenUrl"]);
            request.Headers.Add("Authorization", base64);
            request.Headers.Add("client-operation-code", _config["SapApi:ClientOperationCode"]);
            request.Headers.Add("id-client-invoke", _config["SapApi:IdClientInvoke"]);
            request.Headers.Add("Cookie", "XSRF-TOKEN=f14e729c-fd85-4e42-bd34-5c5064e68d1a");

            request.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<AuthToken>(content);
            if (json == null || string.IsNullOrEmpty(json.AccessToken))
                throw new InvalidOperationException("No se pudo deserializar el token de SAP.");

            var ahora = DateTime.UtcNow;
            var expira = ahora.AddSeconds(json.ExpiresIn);

            await _tokens.InsertOneAsync(new TokenLog
            {
                AuthorizationBase64 = base64,
                AccessToken = json.AccessToken,
                ExpiresIn = json.ExpiresIn,
                FechaGeneracion = ahora,
                FechaExpiracion = expira
            });

            return new TokenResponseDto
            {
                AccessToken = json.AccessToken,
                Expiration = expira,
                TokenType = json.TokenType
            };
        }

        private class AuthToken
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }
        }
    }
}
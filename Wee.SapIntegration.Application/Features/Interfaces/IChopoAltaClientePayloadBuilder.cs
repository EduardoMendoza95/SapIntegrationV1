namespace Wee.SapIntegration.Application.Features.Interfaces;

public interface IClientePayloadBuilder
{
    Task<Dictionary<string, object>> BuildPayloadAsync(Guid idCotizacion);
    string GetEndpointUrl();
    HttpMethod GetHttpMethod();
}
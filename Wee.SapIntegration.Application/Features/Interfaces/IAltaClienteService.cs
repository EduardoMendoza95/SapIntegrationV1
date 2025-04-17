using Wee.SapIntegration.Application.Features.AltaCliente.Dtos;
namespace Wee.SapIntegration.Application.Features.Interfaces
{
    public interface IAltaClienteService
    {
        Task<AltaClienteResponseDto> EnviarClienteASAPAsync(Guid idCotizacion);
    }
}
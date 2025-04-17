using Wee.SapIntegration.Application.Features.Autenticacion.Dtos;

namespace Wee.SapIntegration.Application.Features.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponseDto> ObtenerTokenAsync(); 
    }
}
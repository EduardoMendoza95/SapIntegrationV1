using MediatR;
using Wee.SapIntegration.Application.Features.Autenticacion.Dtos;

namespace Wee.SapIntegration.Application.Features.Autenticacion.Commands
{
    public class GenerarTokenCommand : IRequest<TokenResponseDto> 
    {
    }
}
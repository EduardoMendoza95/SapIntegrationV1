using MediatR;
using Wee.SapIntegration.Application.Features.Autenticacion.Commands;
using Wee.SapIntegration.Application.Features.Interfaces;
using Wee.SapIntegration.Application.Features.Autenticacion.Dtos;

namespace Wee.SapIntegration.Application.Features.Autenticacion.Handlers
{
    public class GenerarTokenHandler : IRequestHandler<GenerarTokenCommand, TokenResponseDto>
    {
        private readonly ITokenService _tokenService;

        public GenerarTokenHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Handle(GenerarTokenCommand request, CancellationToken cancellationToken)
        {
            return await _tokenService.ObtenerTokenAsync();
        }
    }
}


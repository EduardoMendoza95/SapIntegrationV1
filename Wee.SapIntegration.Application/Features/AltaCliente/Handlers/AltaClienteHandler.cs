using MediatR;
using Wee.SapIntegration.Application.Features.AltaCliente.Dtos;
using Wee.SapIntegration.Application.Features.AltaCliente.Commands;
namespace Wee.SapIntegration.Application.Features.Interfaces;


public class AltaClienteHandler : IRequestHandler<AltaClienteCommand, AltaClienteResponseDto>
{
    private readonly IAltaClienteService _altaClienteService;

    public AltaClienteHandler(IAltaClienteService altaClienteService)
    {
        _altaClienteService = altaClienteService;
    }

    public async Task<AltaClienteResponseDto> Handle(AltaClienteCommand request, CancellationToken cancellationToken)
    {
        return await _altaClienteService.EnviarClienteASAPAsync(request.IdCotizacion);
    }
}
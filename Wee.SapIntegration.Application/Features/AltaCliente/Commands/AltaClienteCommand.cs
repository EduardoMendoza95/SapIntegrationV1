using MediatR;
using Wee.SapIntegration.Application.Features.AltaCliente.Dtos;
namespace Wee.SapIntegration.Application.Features.AltaCliente.Commands;

public class AltaClienteCommand : IRequest<AltaClienteResponseDto>
{
    public Guid IdCotizacion { get; set; }

    public AltaClienteCommand(Guid idCotizacion)
    {
        IdCotizacion = idCotizacion;
    }
}
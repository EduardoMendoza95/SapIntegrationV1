using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wee.SapIntegration.Application.Features.AltaCliente.Commands;
using Wee.SapIntegration.Application.Features.AltaCliente.Dtos;

namespace Wee.SapIntegration.API.Controllers;

[ApiController]
[Route("api/")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AltaCliente")]
    public async Task<IActionResult> AltaCliente([FromBody] AltaClienteCommand command)
    {
        var resultado = await _mediator.Send(command);
        return Ok(resultado);
    }
}
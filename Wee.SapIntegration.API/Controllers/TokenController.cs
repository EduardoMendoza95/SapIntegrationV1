using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wee.SapIntegration.Application.Features.Autenticacion.Commands;

namespace Wee.SapIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            var token = await _mediator.Send(new GenerarTokenCommand());
            return Ok(token);
        }
    }
}
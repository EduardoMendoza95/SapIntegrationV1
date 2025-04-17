// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using Wee.Logger;
// using Wee.MessageHub.Application.Features.Mail.Commands;
// using Wee.MessageHub.Shared.Exceptions;



// namespace Wee.SapIntegration.API.Controllers
// {
//     [ServiceFilter(typeof(ValidModelFilter))]
//     public class OrquestadorController : ControllerBase
//     {
//         private readonly IMediator _mediator;
//         private readonly IWeeLogger _logger;

//         public OrquestadorController(IMediator mediator, IWeeLogger logger)
//         {
//             _mediator = mediator;
//             _logger = logger;
//         }

//         [HttpPost("procesar")]
//     public async Task<IActionResult> Procesar([FromBody] ProcesarTodoRequest request)
//     {
//         if (request.CodTipoCotizacion == 1)
//             await _clienteService.EnviarClienteASAP(request.IdCotizacion);

//         // await _convenioService.AltaConvenio(request.IdCotizacion);
//         // await _listaPrecioService.CargarListaPrecios(request.IdCotizacion);

//         return Ok("Proceso completo ejecutado.");
//     }
//     }
// }


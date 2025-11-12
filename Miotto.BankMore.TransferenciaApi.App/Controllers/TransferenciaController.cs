using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miotto.BankMore.TransferenciaApi.App.Commands;
using System.Security.Claims;

namespace Miotto.BankMore.TransferenciaApi.App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewTransferAsync([FromBody] NewTransferRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var token = base.HttpContext.Request.Headers.Authorization;
            var idContaOrigem = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var command = new NewTransferCommand(idContaOrigem, request.NumeroContaDestino, request.Valor, token.ToString());

            await _mediator.Send(command);

            return NoContent();
        }
    }
}

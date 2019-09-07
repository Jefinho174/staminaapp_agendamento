using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StaminaAppAgendamento.Core.Commands;
using StaminaAppAgendamento.Dominio.Commands.ClienteCommands;
using StaminaAppAgendamento.Dominio.Entidades;

namespace StaminaAppAgendamento.Api.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastrar cliente
        /// </summary>
        /// <param name="CadastrarClienteCommand"></param>
        [HttpPost]
        public async Task<ActionResult<CommandResult<Cliente>>> Post([FromBody] CadastrarClienteCommand command)
        {
            var response =  await _mediator.Send(command);
            if(response.Sucesso){
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
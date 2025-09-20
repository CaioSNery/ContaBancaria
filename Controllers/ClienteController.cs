
using ContaBancaria.Shared.Dtos;
using ContaBancaria.Shared.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteService;
        private readonly IContaRepository _contaService;

        public ClienteController(IClienteRepository clienteService, IContaRepository contaService)
        {
            _clienteService = clienteService;
            _contaService = contaService;
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteCreateDTO clientedto)
        {
            var cliente = await _clienteService.AdicionarClienteAsync(clientedto);
            return Ok(cliente);
        }
        [HttpPut("clientes/{id:guid}")]
        public async Task<IActionResult> AtualizarCliente([FromRoute] Guid id, [FromBody] ClienteUpdateDTO dto)
        {
            var cliente = await _clienteService.AtualizarClienteAsync(id, dto);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpPatch("clientes/{id:guid}/contas")]
        public async Task<IActionResult> AtualizarTipoDeContas([FromRoute] Guid id, [FromBody] ContaUpdateDTO contadto)
        {
            var atualizado = await _clienteService.AtualizarTipoDeContasAsync(id, contadto);
            if (!atualizado)
                return NotFound("Cliente não encontrado.");

            return NoContent();
        }
        [HttpDelete("clientes/{id:guid}")]
        public async Task<IActionResult> DeletarClientePorId([FromRoute] Guid id)
        {
            var deletado = await _clienteService.DeletarClientePorIdAsync(id);
            if (!deletado)
                return NotFound("Cliente não encontrado.");

            return NoContent();
        }
    }
}
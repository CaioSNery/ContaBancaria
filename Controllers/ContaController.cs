using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Shared.Dtos;
using ContaBancaria.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost("contas/transferencias")]
        public async Task<IActionResult> Transferir([FromBody] ContaTransferirDTO dto)
        {
            var transferencia = await _contaService.FazerTransferenciaAsync(
                dto.NumeroContaOrigem,
                dto.NumeroContaDestino,
                dto.Valor
            );
            if (!transferencia)
                return BadRequest("Transferência não realizada.");

            return Ok(transferencia);
        }

        [HttpPost("contas/transferencias/pix")]
        public async Task<IActionResult> TransferirPix([FromBody] ContaPIXTransferirDTO dto)
        {

            var transferencia = await _contaService.FazerTransferenciaPixAsync(
                dto.ChavePixOrigem,
                dto.ChavePixDestino,
                dto.Valor
            );
            if (!transferencia)
                return BadRequest("Transferência não realizada, verifique seu saldo.");

            return Ok(transferencia);
        }

        [HttpPost("contas/saques")]
        public async Task<IActionResult> Sacar([FromBody] ContaSaqueDTO dto)
        {
            var saque = await _contaService.FazerSaqueAsync(dto.NumeroConta, dto.Valor);
            if (!saque)
                return BadRequest("Saque não realizado, verifique seu saldo.");

            return Ok(saque);
        }

        [HttpPost("contas/depositos")]
        public async Task<IActionResult> Depositar([FromBody] ContaDepositarDTO dto)
        {
            var deposito = await _contaService.FazerDepositoAsync(dto.NumeroConta, dto.Valor);
            if (!deposito)
                return BadRequest("Depósito não realizado.");

            return Ok(deposito);
        }
        
        
    }
}
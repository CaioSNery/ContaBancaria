using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Enums;

namespace ContaBancaria.Shared.Dtos
{
    public class ClienteCreateDTO
    {
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }
    public ETiposContas TipoConta { get; set; } = ETiposContas.ContaPoupanca;
    }
}
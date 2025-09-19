using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Enums;

namespace ContaBancaria.Shared.Dtos
{
    public class ClienteUpdateDTO
    {
    public string PrimeiroNome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    
    }
}
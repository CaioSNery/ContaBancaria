using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Shared.Dtos
{
    public class ContaTransferirDTO
    {
    public string NumeroContaOrigem { get; set; }= string.Empty;
    public string NumeroContaDestino { get; set; }= string.Empty;
    public decimal Valor { get; set; }

    }
}
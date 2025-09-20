using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Shared.Dtos
{
    public class ContaPIXTransferirDTO
    {
        public string ChavePixOrigem { get; set; }= string.Empty;
        public string ChavePixDestino { get; set; }= string.Empty;
        public decimal Valor { get; set; }
    }
}
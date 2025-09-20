using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Shared.Dtos
{
    public class ContaSaqueDTO
    {
        public string NumeroConta { get; set; }= string.Empty;
        public decimal Valor { get; set; }
    }
}
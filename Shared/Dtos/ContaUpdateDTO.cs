using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Enums;

namespace ContaBancaria.Shared.Dtos
{
    public class ContaUpdateDTO
    {
        public ETiposContas TipoConta { get; set; }
    }
}
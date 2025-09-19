using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Entities.Interface;
using ContaBancaria.Enums;

namespace ContaBancaria.Entities
{
    public abstract class Conta:Entity
    {
        protected Conta(Guid id) : base(id)
        {
        }

        public string Numero { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public bool CartaoCredito { get; protected set; } = false;
        public bool CartaoDebito { get; protected set; } = false;
        public string Pix { get; set; } = string.Empty;
        public DateTime DataAbertura { get; set; }
        public ETiposContas TipoConta { get; set; }


        public abstract void Depositar(decimal valor);
        public abstract void Sacar(decimal valor);
    }
}
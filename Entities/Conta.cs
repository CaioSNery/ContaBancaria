
using ContaBancaria.Enums;
using ContaBancaria.Shared.Entity;

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
        public string? Pix { get; set; }
        public DateTime DataAbertura { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public ETiposContas TipoConta { get; set; }

        public string GerarNumeroConta()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }


        public abstract void Depositar(decimal valor);
        public abstract void Sacar(decimal valor);
    }
}
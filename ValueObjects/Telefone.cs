using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace ContaBancaria.ValueObject
{
    public sealed class Telefone : Shared.ValueObjects.ValueObject
    {
        private Telefone() { }
        //como fazer um telefone
        public Telefone(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract<Telefone>()
                .Requires()
                .IsNotNullOrEmpty(Numero, "Numero", "Numero não pode ser vazio.")
            );
        }
        public static Telefone Create(string numero)
        {
            return new Telefone(numero);
        }
        public string Numero { get; } = null!;
        
    }
}
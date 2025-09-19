using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace ContaBancaria.ValueObject
{
    public sealed class Telefone : Shared.ValueObjects.ValueObject
    {
        //como fazer um telefone
        public Telefone(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract<Telefone>()
                .Requires()
                .IsNotNullOrEmpty(Numero, "Numero", "Numero cannot be empty.")
            );
        }
        public static Telefone Create(string numero)
        {
            return new Telefone(numero);
        }
        public string Numero { get; }
        
    }
}
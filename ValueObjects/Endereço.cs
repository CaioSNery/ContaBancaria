using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace ContaBancaria.ValueObject
{
    public sealed class Endereço : Shared.ValueObjects.ValueObject
    {
         public Endereço(string rua, string cidade, string estado, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            AddNotifications(new Contract<Endereço>()
                .Requires()
                .IsNotNullOrEmpty(Rua, "Rua", "Rua cannot be empty.")
                .IsNotNullOrEmpty(Cidade, "Cidade", "Cidade cannot be empty.")
                .IsNotNullOrEmpty(Estado, "Estado", "Estado cannot be empty.")
                .IsNotNullOrEmpty(Cep, "Cep", "Cep cannot be empty.")
            );
        }
        public static Endereço Create(string rua, string cidade = "", string estado = "", string cep = "")
        {
            return new Endereço(rua, cidade, estado, cep);
        }

        public string Rua { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Cep { get; }


    }
    }

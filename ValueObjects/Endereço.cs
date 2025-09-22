using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace ContaBancaria.ValueObject
{
    public sealed class Endereço : Shared.ValueObjects.ValueObject
    {
        private Endereço() { }
         public Endereço(string rua, string cidade, string estado, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            AddNotifications(new Contract<Endereço>()
                .Requires()
                .IsNotNullOrEmpty(Rua, "Rua", "Rua não pode ser vazia.")
                .IsNotNullOrEmpty(Cidade, "Cidade", "Cidade não pode ser vazia.")
                .IsNotNullOrEmpty(Estado, "Estado", "Estado não pode ser vazio.")
                .IsNotNullOrEmpty(Cep, "Cep", "Cep não pode ser vazio.")
            );
        }
        public static Endereço Create(string rua, string cidade = "", string estado = "", string cep = "")
        {
            return new Endereço(rua, cidade, estado, cep);
        }

        public string Rua { get; }= null!;
        public string Cidade { get; }=null!;
        public string Estado { get; } = null!;
        public string Cep { get; } = null!;


    }
    }


using System.ComponentModel.DataAnnotations;
using ContaBancaria.Entities.Interface;
using ContaBancaria.ValueObject;
using ContaBancaria.ValueObjects;

namespace ContaBancaria.Entities
{
    public sealed class Cliente : Entity
    {

        
        private Cliente(
    string firstName, string lastName,
    string cpf,
    string telefone,
    string endereco,
    DateTime? dataNascimento = null
) : base(Guid.NewGuid())
{
    Nome = Nome.Create(firstName, lastName);
    Cpf = Cpf.Create(cpf);
    Endereco = Endereço.Create(endereco);
    Telefone = Telefone.Create(telefone);
    DataNascimento = dataNascimento ?? default(DateTime);
}

        private Cliente(Nome nome, Cpf cpf, Endereço endereco, Telefone telefone, DateTime? dataNascimento = null)
    : base(Guid.NewGuid())
{
    Nome = nome;
    Cpf = cpf;
    Endereco = endereco;
    Telefone = telefone;
    DataNascimento = dataNascimento ?? default(DateTime);
}

       

        public static Cliente Create(string firstName, string lastName,
         string cpf,
         string telefone,
         string endereco,
         DateTime? dataNascimento = null) 
        {
            var cliente = new Cliente(firstName, lastName, cpf, telefone, endereco, dataNascimento);
            return cliente;
        }

        public static Cliente Create(Nome nome
         , Cpf cpf
         , Endereço endereco
         , Telefone telefone
         , DateTime? dataNascimento = null)
        {
            var cliente = new Cliente(nome, cpf, endereco, telefone, dataNascimento);

            return cliente;
        }


        public Nome Nome { get; }
        public Cpf Cpf { get; }
        public DateTime DataNascimento { get; set; }
        public Telefone Telefone { get; }
        public Endereço Endereco { get; }
        public Conta Conta { get; set; }
        
        public override string ToString() => Nome;

        
    }
}
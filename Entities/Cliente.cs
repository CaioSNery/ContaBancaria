using System;
using ContaBancaria.Enums;
using ContaBancaria.Shared.Entity;
using ContaBancaria.ValueObject;
using ContaBancaria.ValueObjects;

namespace ContaBancaria.Entities
{
    public sealed class Cliente : Entity
    {
        public Nome Nome { get; }
        public Cpf Cpf { get; }
        public DateTime DataNascimento { get; set; }
        public Telefone Telefone { get; }
        public Endereço Endereco { get; }
        public Conta Conta { get; private set; }


        private Cliente(
            Nome nome,
            Cpf cpf,
            Telefone telefone,
            Endereço endereco,
            ETiposContas tipoConta = ETiposContas.ContaPoupanca,
            DateTime? dataNascimento = null
        ) : base(Guid.NewGuid())
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            DataNascimento = dataNascimento ?? default;

            
            Conta = tipoConta switch
            {
                ETiposContas.ContaCorrente => new ContaCorrente
                {
                    Numero = Conta.GerarNumeroConta(),
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                },
                ETiposContas.ContaPoupanca => new ContaPoupanca
                {
                    Numero = Conta.GerarNumeroConta(),
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                },
                _ => new ContaSalario
                {
                    Numero = Conta.GerarNumeroConta(),
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                }
            };
        }

        
        public static Cliente Create(
            string primeiroNome,
            string sobrenome,
            string cpf,
            string telefone,
            string logradouro,
            ETiposContas tipoConta = ETiposContas.ContaPoupanca,
            DateTime? dataNascimento = null
        )
        {
            var nome = Nome.Create(primeiroNome, sobrenome);
            var cpfVo = Cpf.Create(cpf);
            var telefoneVo = Telefone.Create(telefone);
            var enderecoVo = Endereço.Create(logradouro);

            return new Cliente(nome, cpfVo, telefoneVo, enderecoVo, tipoConta, dataNascimento);
        }
    }
}


    



        

        
  
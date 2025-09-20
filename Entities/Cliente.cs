using System;
using ContaBancaria.Enums;
using ContaBancaria.Shared.Entity;
using ContaBancaria.ValueObject;
using ContaBancaria.ValueObjects;

namespace ContaBancaria.Entities
{
    public sealed class Cliente : Entity
    {
        public Nome Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DataNascimento { get; set; }
        public Telefone Telefone { get; private set; }
        public Endereço Endereco { get; private set; }
        public Senha Senha { get; private set; }
        public Conta Conta { get; private set; }
        public ETiposContas TipoConta { get; private set; }

        public ICollection<Conta> Contas { get; set; } = new List<Conta>();

        public void AtualizarDados(string primeiroNome, string sobrenome, string cpf, DateTime dataNascimento)
        {
            Nome = Nome.Create(primeiroNome, sobrenome);
            Cpf = Cpf.Create(cpf);
            DataNascimento = dataNascimento;
        }

        public void AtualizarTipoDeConta(ETiposContas tipoConta)
        {
            if (TipoConta != tipoConta)
            {
                TipoConta = tipoConta;
                Conta = CriarConta(tipoConta);
            }
        }


        private Cliente(
            Nome nome,
            Cpf cpf,
            Telefone telefone,
            Endereço endereco,
            Senha senha,
            ETiposContas tipoConta = ETiposContas.ContaPoupanca,
            DateTime? dataNascimento = null
        ) : base(Guid.NewGuid())
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
            DataNascimento = dataNascimento ?? default;
            TipoConta = tipoConta;
            Conta = CriarConta(tipoConta);
        }




        public static Cliente Create(
            string primeiroNome,
            string sobrenome,
            string cpf,
            string telefone,
            string senha,
            string logradouro,
            ETiposContas tipoConta = ETiposContas.ContaPoupanca,
            DateTime? dataNascimento = null
        )
        {
            var nome = Nome.Create(primeiroNome, sobrenome);
            var cpfVo = Cpf.Create(cpf);
            var senhaVo = Senha.Create(senha);
            var telefoneVo = Telefone.Create(telefone);
            var enderecoVo = Endereço.Create(logradouro);

            return new Cliente(nome, cpfVo, telefoneVo, enderecoVo, senhaVo, tipoConta, dataNascimento);
        }

        private Conta CriarConta(ETiposContas tipoConta)
        {
            return tipoConta switch
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
    }
}



    



        

        
  
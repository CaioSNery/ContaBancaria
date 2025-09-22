using System;
using ContaBancaria.Enums;
using ContaBancaria.Shared.Entity;
using ContaBancaria.ValueObject;
using ContaBancaria.ValueObjects;

namespace ContaBancaria.Entities
{
    public sealed class Cliente : Entity
    {
       
       private Cliente(): base(Guid.NewGuid())
        {
        }

        public Nome Nome { get; private set; } = null!;
        public Cpf Cpf { get; private set; } = null!;
        public DateTime DataNascimento { get; set; }
        public Telefone Telefone { get; private set; } = null!;
        public Endereço Endereco { get; private set; } = null!;
        public Senha Senha { get; private set; } = null!;
       
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
                var novaconta=CriarConta(tipoConta);
                Contas.Add(novaconta);
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
            Contas.Add(CriarConta(tipoConta));
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
            var conta = tipoConta switch
            {
                ETiposContas.ContaCorrente => (Conta)new ContaCorrente
                {
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                },
                ETiposContas.ContaPoupanca => (Conta)new ContaPoupanca
                {
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                },
                _ => (Conta)new ContaSalario
                {
                    Agencia = "0001",
                    DataAbertura = DateTime.Now
                }
            };
            conta.Numero = conta.GerarNumeroConta();
            return conta;
        }
    }
}



    



        

        
  
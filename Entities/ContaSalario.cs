using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Entities
{
    public class ContaSalario : Conta
    {
        public ContaSalario() : base(Guid.NewGuid())
        {
            CartaoCredito = false;
            CartaoDebito = true;
        }
        public override void Depositar(decimal valor)
        {
            try
            {
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do depósito deve ser maior que zero.");
                }

                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar o depósito: {ex.Message}");
            }
        }

        public override void Sacar(decimal valor)
        {
            Console.WriteLine("Saque não permitido em Conta Salário.");
            return;
        }

        public void PagarDebito(decimal valor)
        {
            try
            {
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do pagamento deve ser maior que zero.");
                }

                if (Saldo < valor)
                {
                    throw new InvalidOperationException("Saldo insuficiente.");
                }

                Saldo -= valor;
                Console.WriteLine($"Pagamento de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar o pagamento: {ex.Message}");
            }
        }
    }
}
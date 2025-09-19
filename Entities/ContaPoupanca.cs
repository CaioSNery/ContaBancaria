using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca()
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
            try
            {
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do saque deve ser maior que zero.");
                }

                if (Saldo < valor)
                {
                    throw new InvalidOperationException("Saldo insuficiente.");
                }

                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar o saque: {ex.Message}");
            }
        }
    }
}
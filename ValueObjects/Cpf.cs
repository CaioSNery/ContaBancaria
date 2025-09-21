using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace ContaBancaria.ValueObject
{
    public sealed class Cpf: Shared.ValueObjects.ValueObject
    {
        #region Constants
        private const int CpfLength = 11;

        #endregion

        #region Constructors
        public Cpf(string value)
        {
            Value = value;

            AddNotifications(new Contract<Cpf>()
                .Requires()
                .IsNotNullOrEmpty(Value, "Cpf", "CPF cannot be empty.")

            );
        }
        #endregion

        #region Factory Method
        public static Cpf Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF cannot be empty.");

            
            var original = value.Trim();

            
            value = original.Replace(".", "").Replace("-", "");

            if (value.Length != CpfLength || !value.All(char.IsDigit))
                throw new ArgumentException("Invalid CPF format.");

            if (!IsValidCpf(value))
                throw new ArgumentException("Invalid CPF number.");



            return new Cpf(value);
        }

        public static bool IsValidCpf(string cpf)
        {
            if (cpf.Distinct().Count() == 1) 
                return false;
            return true;
        }



        #endregion

        #region Properties
        public string Value { get; }
        public string Formatted =>
    $"{Value.Substring(0, 3)}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value.Substring(9, 2)}";
        #endregion
    }
}
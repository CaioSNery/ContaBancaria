using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ContaBancaria.ValueObjects
{
    public sealed class Senha : Shared.ValueObjects.ValueObject
    {
        #region Constants
        private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string Especial = "!@#$%^&*()_+[]{}|;:,.<>?";
        #endregion

        #region Constructors
        public Senha(string? text = null)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                text = Generate();

            Hash = Hashing(text);
        }
        private static string Generate(
           short length = 16,
           bool includeSpecialCharacters = true,
           bool upperCase = false)
        {
            var chars = includeSpecialCharacters ? (Valid + Especial) : Valid;
            var startRandom = upperCase ? 26 : 0;
            var index = 0;
            var res = new char[length];
            var random = new Random();

            while (index < length)
            {
                res[index++] = chars[random.Next(startRandom, chars.Length)];
            }

            return new string(res);
        }

        private static string Hashing(
          string password,
          short saltSize = 16,
          short keySize = 32,
          int iterations = 10000,
          char splitChar = '.')
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(password));

            password += Configuration.Secrets.PasswordSaltKey;

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                saltSize,
                iterations,
                HashAlgorithmName.SHA256);

            var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{iterations} {splitChar} {salt} {splitChar} {key}";
        }

        private static bool Verify(
            string hash,
            string password,
            short keySize = 32,
            int iterations = 10000,
            char splitChar = '.')
        {
            password += Configuration.Secrets.PasswordSaltKey;

            var parts = hash.Split(splitChar, 3);
            if (parts.Length != 3)
                return false;

            var hashIterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            if (hashIterations != iterations)
                return false;

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                hashIterations,
                HashAlgorithmName.SHA256);

            var keyToCompare = algorithm.GetBytes(keySize);
            return keyToCompare.SequenceEqual(key);

        }
        #endregion

        #region Factory Method
        public static Senha Create(string? text = null) => new Senha(text);

        public static new bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8 || password.Length > 64)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            if (!password.Any(ch => Especial.Contains(ch)))
                return false;

            return true;
        }


        #endregion

        #region Methods

        public bool Challenge(string plainTextPassword) =>
            Verify(Hash, plainTextPassword);
        #endregion

        #region Properties
        public string Hash { get; private set; } = string.Empty;
        public string ResetCode { get; private set; } = string.Empty;

        #endregion


    }
        
    }
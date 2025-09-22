

namespace ContaBancaria.ValueObjects
{
    public sealed class Nome : Shared.ValueObjects.ValueObject
    {
        private Nome() { }

        #region Constants
        public const int MinLength = 2;
        public const int MaxLength = 50;

        #endregion

        #region Constructors
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }
        
        #endregion

        #region Factory Method
        public static Nome Create(string primeiroNome, string sobrenome)
        {

            if (string.IsNullOrWhiteSpace(primeiroNome))
                throw new ArgumentException("Primeiro nome não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("Sobrenome não pode ser vazio.");

            if (primeiroNome.Length < MinLength || primeiroNome.Length > MaxLength)
                throw new ArgumentException($"Primeiro nome deve ter entre {MinLength} e {MaxLength} caracteres.");

            if (sobrenome.Length < MinLength || sobrenome.Length > MaxLength)
                throw new ArgumentException($"Sobrenome deve ter entre {MinLength} e {MaxLength} caracteres.");

            return new Nome(primeiroNome, sobrenome);
        }
        #endregion

        #region Properties
        public static implicit operator string(Nome nome) => nome.ToString();
        public string PrimeiroNome { get; } = null!;
        public string Sobrenome { get; } = null!;

        public override string ToString() => $"{PrimeiroNome} {Sobrenome}";
        #endregion
    }
}
        
        

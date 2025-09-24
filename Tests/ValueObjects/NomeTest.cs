
using ContaBancaria.ValueObjects;
using Xunit;

namespace ContaBancaria.Tests.ValueObjects
{
    public class NomeTest
    {
        private readonly Nome _nome = Nome.Create("João", "Silva");
        [Fact]
        public void DeveCriarNomeValido()
        {
            Assert.Equal("Joao Silva", _nome.ToString());
        }

        [Fact]
        public void DeveRetornarErroQuandoCaracterForInvalido()
        {
            Assert.Throws<ArgumentException>(() => Nome.Create("John", "q"));
            Assert.Throws<ArgumentException>(() => Nome.Create("J", "Doe"));
            Assert.Throws<ArgumentException>(() => Nome.Create(new string('a', 51), "Doe"));
            Assert.Throws<ArgumentException>(() => Nome.Create("John", new string('a', 51)));
        }
        
    }
}
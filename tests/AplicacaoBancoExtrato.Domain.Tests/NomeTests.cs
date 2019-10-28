namespace AplicacaoBancoExtrato.DomainTests
{
    using AplicacaoBancoExtrato.Domain.ValueObjects;
    using Xunit;

    public class NomeTests
    {
        [Fact]
        public void ValidaNomeEmBranco()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<NomeNaoPodeSerVazioException>(
                () => new Nome(empty));
        }

        [Fact]
        public void ValidaNomeCompleto()
        {
            //
            // Arrange
            string valido = "Everton Varago";

            //
            // Act
            Nome nome = new Nome(valido);

            //
            // Assert
            Assert.Equal(new Nome(valido), nome);
        }
    }
}

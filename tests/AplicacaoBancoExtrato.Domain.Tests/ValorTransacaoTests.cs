namespace AplicacaoBancoExtrato.DomainTests
{
    using AplicacaoBancoExtrato.Domain.ValueObjects;
    using System;
    using Xunit;

    public class ValorTransacaoTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void Criar_ValorTransacao(decimal value)
        {
            //
            // Arrange
            decimal valorTransacaoPositivo = value;

            //
            // Act
            ValorTransacao valorTransacao = new ValorTransacao(valorTransacaoPositivo);

            //
            // Assert
            Assert.Equal<decimal>(valorTransacaoPositivo, valorTransacao);
        }

        [Fact]
        public void ValorTransacao_Com_100_Menos_70_Deve_Ser_30()
        {
            //
            // Arrange
            ValorTransacao cem = new ValorTransacao(100);
            ValorTransacao setenta = new ValorTransacao(70);

            //
            // Act
            ValorTransacao valorTransacao = cem - setenta;

            //
            // Assert
            Assert.Equal(30, valorTransacao);
        }

        [Fact]
        public void ValorTransacao_Com_100_Maior_Que_70()
        {
            //
            // Arrange
            ValorTransacao cem = new ValorTransacao(100);
            ValorTransacao setenta = new ValorTransacao(70);

            //
            // Act & Assert
            Assert.True(cem > setenta);
        }

        [Fact]
        public void ValorTransacao_Com_30_Menor_Ou_Igual_30()
        {
            //
            // Arrange
            ValorTransacao trinta = new ValorTransacao(30);
            ValorTransacao setenta = new ValorTransacao(70);

            //
            // Act & Assert
            Assert.True(trinta <= setenta);
        }
    }
}

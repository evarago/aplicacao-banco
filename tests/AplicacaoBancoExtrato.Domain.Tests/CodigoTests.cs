namespace AplicacaoBancoExtrato.DomainTests
{
    using AplicacaoBancoExtrato.Domain.ValueObjects;
    using Xunit;

    public class CodigoTests
    {
        [Fact]
        public void Codigo_Em_Branco_Nao_Deve_Ser_Cadastrado()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<CodigoPessoaNaoPodeSerVazioException>(
                () => new CodigoPessoa(empty));
        }

        [Fact]
        public void Codigo_Valido_Deve_Ser_Criado()
        {
            //
            // Arrange
            string valido = "08724050601";

            //
            // Act
            CodigoPessoa codigo = new CodigoPessoa(valido);

            // Assert
            Assert.Equal(valido, codigo);
        }
    }
}
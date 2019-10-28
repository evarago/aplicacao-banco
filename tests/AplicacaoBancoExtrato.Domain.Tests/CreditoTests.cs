namespace AplicacaoBancoExtrato.DomainTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Domain.Contas;
    using System;

    public class CreditoTests
    {
        [Fact]
        public void Credito_Deve_Ser_Carregado()
        {
            Credito credito = Credito.CarregarDetalhes(
                Guid.Empty,
                Guid.Empty,
                100,
                DateTime.Today,
                "xxx");

            Assert.Equal(Guid.Empty, credito.Id);
            Assert.Equal(Guid.Empty, credito.IdConta);
            Assert.Equal(100, credito.ValorTransacao);
            Assert.Equal(DateTime.Today, credito.DataTransacao);
            Assert.Equal("Crédito", credito.Descricao);
        }
    }
}
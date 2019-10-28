namespace AplicacaoBancoExtrato.DomainTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Domain.Contas;
    using System;

    public class DebitoTests
    {
        [Fact]
        public void Debito_Deve_Ser_Carregado()
        {
            Debito debito = Debito.CarregarDetalhes(
                Guid.Empty,
                Guid.Empty,
                100,
                DateTime.Today, 
                "xxxx");

            Assert.Equal(Guid.Empty, debito.Id);
            Assert.Equal(Guid.Empty, debito.IdConta);
            Assert.Equal(100, debito.ValorTransacao);
            Assert.Equal(DateTime.Today, debito.DataTransacao);
            Assert.Equal("Débito", debito.Descricao);
        }
    }
}
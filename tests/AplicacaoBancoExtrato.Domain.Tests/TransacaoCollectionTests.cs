namespace AplicacaoBancoExtrato.DomainTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Domain.Contas;
    using System;
    using System.Collections.Generic;

    public class TransacaoCollectionTests
    {
        [Fact]
        public void TransacoesMultiplasDevemSerCadastradas()
        {
            TransacaoCollection transacaoCollection = new TransacaoCollection();
            transacaoCollection.Add(new List<ITransacao>()
            {
                new Credito(Guid.Empty, 100, "xxxx"),
                new Debito(Guid.Empty, 30, "xxxx")
            });

            Assert.Equal(2, transacaoCollection.ToReadOnlyCollection().Count);
        }
    }
}
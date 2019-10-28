namespace AplicacaoBancoExtrato.DomainTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Domain.Clientes;
    using AplicacaoBancoExtrato.Domain.Contas;
    using System;

    public class ClienteTests
    {
        [Fact]
        public void Cliente_Deve_Ser_Cadastrado_Com_1_Conta()
        {
            //
            // Arrange
            Cliente sut = new Cliente(
                "741214-3054",
                "Nome do novo cliente");

            var Conta = new Conta(sut.Id);

            //
            // Act
            sut.Cadastrar(Conta.Id);

            //
            // Assert
            Assert.Single(sut.Contas.ToReadOnlyCollection());
        }

        [Fact]
        public void Cliente_Deve_Ser_Carregado()
        {
            //
            // Arrange
            ContaCollection contas = new ContaCollection();
            contas.Add(Guid.NewGuid());

            Guid idCliente = Guid.NewGuid();

            Cliente Cliente = Cliente.CarregarDetalhes(
                idCliente,
                "Nome do novo cliente",
                "741214-3054",
                contas);

            Assert.Equal(idCliente, Cliente.Id);
            Assert.Equal("Nome do novo cliente", Cliente.Nome);
            Assert.Equal("741214-3054", Cliente.Codigo);
        }
    }
}

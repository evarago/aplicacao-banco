namespace AplicacaoBancoExtrato.DomainTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Domain.ValueObjects;
    using System;
    using Moq;
    using AplicacaoBancoExtrato.Domain.Contas;

    public class ContaTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(0)]
        [InlineData(400)]
        public void Deposito_Deve_Mudar_Saldo(decimal valorParaDeposito)
        {
            //
            // Arrange
            Guid idCliente = Guid.NewGuid();
            Conta sut = new Conta(idCliente);
            ValorTransacao valorTransacao = new ValorTransacao(valorParaDeposito);

            //
            // Act
            sut.Deposito(valorTransacao, "xxxx");

            //
            // Assert
            ValorTransacao balance = sut.GetSaldoAtual();

            Assert.Equal(idCliente, sut.IdCliente);
            Assert.Equal(valorParaDeposito, (decimal)balance);
        }

        [Fact]
        public void Deposito_Deve_Alterar_Saldo_Quando_Conta_E_Nova()
        {
            //
            // Arrange
            Guid novoIdCliente = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            ValorTransacao valorDepositoEsperado = new ValorTransacao(400m);

            //
            // Act
            Conta sut = new Conta(novoIdCliente);
            sut.Deposito(valorDepositoEsperado, "xxxx");
            ValorTransacao balance = sut.GetSaldoAtual();

            //
            // Assert
            Assert.Equal(novoIdCliente, sut.IdCliente);
            Assert.Equal(valorDepositoEsperado, balance);
            Assert.Single(sut.Transacoes.ToReadOnlyCollection());
        }

        [Fact]
        public void Deposito_Deve_Altera_Saldo_Valor_Equivalente()
        {
            //
            // Arrange
            Guid novoIdCliente = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            ValorTransacao valorDepositoEsperado = new ValorTransacao(400m);

            //
            // Act
            Conta sut = new Conta(novoIdCliente);
            sut.Deposito(valorDepositoEsperado, "xxxx");
            ValorTransacao balance = sut.GetSaldoAtual();

            //
            // Assert
            Assert.Equal(valorDepositoEsperado, balance);
        }

        [Fact]
        public void Deposito_Deve_Adicionar_Transacao()
        {
            //
            // Arrange
            Guid novoIdCliente = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            ValorTransacao valorDepositoEsperado = new ValorTransacao(400m);

            //
            // Act
            Conta sut = new Conta(novoIdCliente);
            sut.Deposito(valorDepositoEsperado, "xxxx");

            //
            // Assert
            Assert.Single(sut.Transacoes.ToReadOnlyCollection());
        }

        [Fact]
        public void NovaConta_Deve_Retornar_O_IdCliente_Correto()
        {
            //
            // Arrange
            Guid novoIdCliente = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            ValorTransacao valorDepositoEsperado = new ValorTransacao(400m);

            //
            // Act
            Conta sut = new Conta(novoIdCliente);

            //
            // Assert
            Assert.Equal(novoIdCliente, sut.IdCliente);
        }

        [Fact]
        public void Nova_Conta_Com_1000_Saldo_Deve_Ter_900_Credito_Depois_Saque()
        {
            //
            // Arrange
            Conta sut = new Conta(Guid.NewGuid());
            sut.Deposito(1000.0m, "xxxx");

            //
            // Act
            sut.Saque(100, "xxxx");

            //
            // Assert
            Assert.Equal(900, sut.GetSaldoAtual());
        }

        [Fact]
        public void Nova_Conta_Deve_Permitir_Encerramento()
        {
            //
            // Arrange
            Conta sut = new Conta(Guid.NewGuid());

            //
            // Act
            sut.Fecha();

            //
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Conta_Com_Saldo_Nao_Deve_Permitir_Encerrmento()
        {
            //
            // Arrange
            Conta sut = new Conta(Guid.NewGuid());
            sut.Deposito(100, "xxxx");

            //
            // Act and Assert
            Assert.Throws<ContaNaoPodeSerFechadaException>(
                () => sut.Fecha());
        }


        [Fact]
        public void Conta_Com_200_Saldo_Nao_Deve_Permitir_50000_Saque()
        {
            //
            // Arrange
            Conta sut = new Conta(Guid.NewGuid());
            sut.Deposito(200, "xxxx");

            //
            // Act and Assert
            Assert.Throws<InsuficientFundsException>(
                () => sut.Saque(5000, "xxxx"));
        }

        [Fact]
        public void Conta_Com_Tres_Transacoes_Deve_Ser_Consistida()
        {
            //
            // Arrange
            Conta sut = new Conta(Guid.NewGuid());
            sut.Deposito(200, "xxxx");
            sut.Saque(100, "xxxx");
            sut.Deposito(50, "xxxx");

            //
            // Act and Assert

            var transactions = sut.Transacoes;

            Assert.Equal(3, transactions.ToReadOnlyCollection().Count); 
        }

        [Fact]
        public void Conta_Deve_Ser_Carregada()
        {
            //
            // Arrange
            TransacaoCollection transacoes = new TransacaoCollection();
            transacoes.Add(new Debito(Guid.Empty, 100, "xxxx"));

            //
            // Act
            Conta conta = Conta.CarregarDetalhes(
                Guid.Empty,
                Guid.Empty,
                transacoes);

            //
            // Assert
            Assert.Single(conta.Transacoes.ToReadOnlyCollection());
            Assert.Equal(Guid.Empty, conta.Id);
            Assert.Equal(Guid.Empty, conta.IdCliente);
        }

        [Fact]
        public void Deposito_Deve_Gerar_Excecao_Quando_Valore_Negativo()
        {
            //
            // Arrange and Act
            Conta sut = new Conta(Guid.NewGuid());
            Exception ex = Record.Exception(() => sut.Deposito(-200, "xxxx"));

            //
            // Assert
            Assert.NotNull(ex);
        }

        [Fact]
        public void Saque_Deve_Gerar_Excecao_Quando_Valor_Negative()
        {
            //
            // Arrange and Act
            Conta sut = new Conta(Guid.NewGuid());
            Exception ex = Record.Exception(() => sut.Saque(-200, "xxxx"));

            //
            // Assert
            Assert.NotNull(ex);
        }
    }
}
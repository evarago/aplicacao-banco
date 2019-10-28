namespace AplicacaoBancoExtrato.UseCaseTests
{
    using Xunit;
    using System;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Application.UseCases.Cadastro;
    using Moq;
    using AplicacaoBancoExtrato.Application.UseCases.Deposito;
    using AplicacaoBancoExtrato.Application.UseCases.Saque;
    using System.Threading.Tasks;

    public class ContaTests
    {
        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void DepositoValorValido(string idConta, decimal valor)
        {
            var mockContaReadOnlyRepository = new Mock<IContaReadOnlyRepository>();
            var mockContaWriteOnlyRepository = new Mock<IContaWriteOnlyRepository>();

            Conta conta = new Conta(Guid.Parse(idConta));

            mockContaReadOnlyRepository.SetupSequence(e => e.Get(It.IsAny<Guid>()))
                .ReturnsAsync(conta);
            
            DepositoUseCase sut = new DepositoUseCase(
                mockContaReadOnlyRepository.Object,
                mockContaWriteOnlyRepository.Object
            );

            DepositoOutput output = await sut.Execute(
                Guid.Parse(idConta),
                valor,
                "xxxx");

            Assert.Equal(100, output.SaldoAtualizado);
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void SaqueValorValido(string idConta, decimal valor)
        {
            var mockContaReadOnlyRepository = new Mock<IContaReadOnlyRepository>();
            var mockContaWriteOnlyRepository = new Mock<IContaWriteOnlyRepository>();
            TransacaoCollection transacoes = new TransacaoCollection();
            transacoes.Add(new Credito(Guid.Empty, 4000, "xxx"));

            Conta account = Conta.CarregarDetalhes(Guid.Parse(idConta), Guid.Empty, transacoes);

            mockContaReadOnlyRepository.SetupSequence(e => e.Get(It.IsAny<Guid>()))
                .ReturnsAsync(account);

            SaqueUseCase sut = new SaqueUseCase(
                mockContaReadOnlyRepository.Object,
                mockContaWriteOnlyRepository.Object
            );

            SaqueOutput output = await sut.Execute(
                Guid.Parse(idConta),
                valor,
                "xxxx");

            Assert.Equal(3900, output.SaldoAtualizado);
        }

        [Theory]
        [InlineData(100)]
        public void ContaComSaldoNaoDeveSerEncerrada(decimal valor)
        {
            Conta conta = new Conta(Guid.NewGuid());
            conta.Deposito(valor, "xxxx");

            Assert.Throws<ContaNaoPodeSerFechadaException>(
                () => conta.Fecha());
        }
    }
}
namespace AplicacaoBancoExtrato.UseCaseTests
{
    using Xunit;
    using AplicacaoBancoExtrato.Application.UseCases.Cadastro;
    using AplicacaoBancoExtrato.Application.Repositories;
    using Moq;

    public class ClienteTests
    {
        [Theory]
        [InlineData(300)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(3300)]
        public async void CadastroContaClienteValido(decimal valor)
        {
            string codigo = "8608178888";
            string nome = "Everton Varago";

            var mockClienteWriteOnlyRepository = new Mock<IClienteWriteOnlyRepository>();
            var mockContaWriteOnlyRepository = new Mock<IContaWriteOnlyRepository>();

            CadastroUseCase sut = new CadastroUseCase(
                mockClienteWriteOnlyRepository.Object,
                mockContaWriteOnlyRepository.Object
            );

            CadastroOutput output = await sut.Execute(
                codigo,
                nome,
                valor,
                "xxxx");

            Assert.Equal(valor, output.Conta.SaldoAtual);
        }
    }
}
namespace AplicacaoBancoExtrato.Application.UseCases.Cadastro {
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public interface ICadastroUseCase {
        Task<CadastroOutput> Execute (CodigoPessoa codigo, Nome nome, ValorTransacao valorInicial, string contaOrigem);
    }
}
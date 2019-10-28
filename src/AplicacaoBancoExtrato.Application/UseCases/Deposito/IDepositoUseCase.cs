namespace AplicacaoBancoExtrato.Application.UseCases.Deposito {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public interface IDepositoUseCase {
        Task<DepositoOutput> Execute (Guid idConta, ValorTransacao valorTransacao, string contaOrigem);
    }
}
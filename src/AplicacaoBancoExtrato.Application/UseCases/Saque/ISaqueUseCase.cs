namespace AplicacaoBancoExtrato.Application.UseCases.Saque {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public interface ISaqueUseCase {
        Task<SaqueOutput> Execute (Guid idConta, ValorTransacao valorTransacao, string contaDestino);
    }
}
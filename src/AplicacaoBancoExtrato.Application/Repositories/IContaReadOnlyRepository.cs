namespace AplicacaoBancoExtrato.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Domain.Contas;

    public interface IContaReadOnlyRepository {
        Task<Conta> Get (Guid id);
    }
}
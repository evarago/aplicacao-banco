namespace AplicacaoBancoExtrato.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public interface IClienteReadOnlyRepository {
        Task<Cliente> Get (Guid id);
    }
}
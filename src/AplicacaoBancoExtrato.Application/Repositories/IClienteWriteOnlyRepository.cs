namespace AplicacaoBancoExtrato.Application.Repositories {
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public interface IClienteWriteOnlyRepository {
        Task Add (Cliente cliente);
        Task Update (Cliente cliente);
    }
}
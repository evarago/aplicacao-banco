namespace AplicacaoBancoExtrato.Application.Repositories {
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Domain.Contas;

    public interface IContaWriteOnlyRepository {
        Task Add (Conta conta, Credito credito);
        Task Update (Conta conta, Credito credito);
        Task Update (Conta conta, Debito debito);
        Task Delete (Conta conta);
    }
}
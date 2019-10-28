namespace AplicacaoBancoExtrato.Infrastructure.InMemoryDataAccess {
    using System.Collections.ObjectModel;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public sealed class AplicacaoBancoExtratoContext {
        public Collection<Cliente> Clientes { get; set; }
        public Collection<Conta> Contas { get; set; }

        public AplicacaoBancoExtratoContext () {
            Clientes = new Collection<Cliente> ();
            Contas = new Collection<Conta> ();
        }
    }
}
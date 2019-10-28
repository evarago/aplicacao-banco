namespace AplicacaoBancoExtrato.Infrastructure.InMemoryDataAccess.Repositories {
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public class ClienteRepository : IClienteReadOnlyRepository, IClienteWriteOnlyRepository {
        private readonly AplicacaoBancoExtratoContext _context;

        public ClienteRepository (AplicacaoBancoExtratoContext context) {
            _context = context;
        }

        public async Task Add (Cliente cliente) {
            _context.Clientes.Add (cliente);
            await Task.CompletedTask;
        }

        public async Task<Cliente> Get (Guid id) {
            Cliente cliente = _context.Clientes
                .Where (e => e.Id == id)
                .SingleOrDefault ();

            return await Task.FromResult<Cliente> (cliente);
        }

        public async Task Update (Cliente cliente) {
            Cliente customerOld = _context.Clientes
                .Where (e => e.Id == cliente.Id)
                .SingleOrDefault ();

            customerOld = cliente;
            await Task.CompletedTask;
        }
    }
}
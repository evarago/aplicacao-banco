namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess {
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Clientes;
    using Microsoft.EntityFrameworkCore;

    public class ClienteRepository : IClienteReadOnlyRepository, IClienteWriteOnlyRepository {
        private readonly AplicacaoBancoExtratoContext _context;

        public ClienteRepository (AplicacaoBancoExtratoContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task Add(Cliente cliente) {
            Entities.Cliente clienteEntity = new Entities.Cliente() {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Codigo = cliente.Codigo
            };

            await _context.Clientes.AddAsync(clienteEntity);
            await _context.SaveChangesAsync ();
        }

        public async Task<Cliente> Get(Guid id) {
            Entities.Cliente cliente = await _context.Clientes
                .FindAsync(id);

            List<Guid> contas = await _context.Contas
                .Where (e => e.IdCliente == id)
                .Select (p => p.Id)
                .ToListAsync ();

            ContaCollection contaCollection = new ContaCollection ();
            foreach (var idConta in contas)
                contaCollection.Add(idConta);

            return Cliente.CarregarDetalhes(cliente.Id, cliente.Nome, cliente.Codigo, contaCollection);
        }

        public async Task Update (Cliente cliente) {
            Entities.Cliente clienteEntity = new Entities.Cliente () {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Codigo = cliente.Codigo
            };

            _context.Clientes.Update(clienteEntity);
            await _context.SaveChangesAsync ();
        }
    }
}
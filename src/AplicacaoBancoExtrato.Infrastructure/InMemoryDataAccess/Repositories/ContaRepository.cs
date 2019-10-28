namespace AplicacaoBancoExtrato.Infrastructure.InMemoryDataAccess.Repositories {
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;

    public class ContaRepository : IContaReadOnlyRepository, IContaWriteOnlyRepository {
        private readonly AplicacaoBancoExtratoContext _context;

        public ContaRepository (AplicacaoBancoExtratoContext context) {
            _context = context;
        }

        public async Task Add (Conta conta, Credito credito) {
            _context.Contas.Add (conta);
            await Task.CompletedTask;
        }

        public async Task Delete (Conta conta) {
            Conta ContaOld = _context.Contas
                .Where (e => e.Id == conta.Id)
                .SingleOrDefault ();

            _context.Contas.Remove (ContaOld);

            await Task.CompletedTask;
        }

        public async Task<Conta> Get (Guid id) {
            Conta Conta = _context.Contas
                .Where (e => e.Id == id)
                .SingleOrDefault ();

            return await Task.FromResult<Conta> (Conta);
        }

        public async Task Update (Conta conta, Credito credito) {
            Conta ContaOld = _context.Contas
                .Where (e => e.Id == conta.Id)
                .SingleOrDefault ();

            ContaOld = conta;
            await Task.CompletedTask;
        }

        public async Task Update (Conta conta, Debito debito) {
            Conta ContaOld = _context.Contas
                .Where (e => e.Id == conta.Id)
                .SingleOrDefault ();

            ContaOld = conta;
            await Task.CompletedTask;
        }
    }
}
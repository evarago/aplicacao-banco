namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess {
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;
    using Microsoft.EntityFrameworkCore;

    public class ContaRepository : IContaReadOnlyRepository, IContaWriteOnlyRepository {
        private readonly AplicacaoBancoExtratoContext _context;

        public ContaRepository (AplicacaoBancoExtratoContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task Add (Conta conta, Credito credito) {
            Entities.Conta contaEntity = new Entities.Conta () {
                IdCliente = conta.IdCliente,
                Id = conta.Id
            };

            Entities.Credito creditoEntity = new Entities.Credito () {
                IdConta = credito.IdConta,
                ValorTransacao = credito.ValorTransacao,
                Id = credito.Id,
                DataTransacao = credito.DataTransacao,
                ContaOrigemDestino = credito.ContaOrigemDestino
            };

            await _context.Contas.AddAsync (contaEntity);
            await _context.Creditos.AddAsync (creditoEntity);
            await _context.SaveChangesAsync ();
        }

        public async Task Delete (Conta conta) {
            string deleteSQL =
                @"DELETE FROM Credito WHERE IdConta = @Id;
                      DELETE FROM Debito WHERE IdConta = @Id;
                      DELETE FROM Conta WHERE Id = @Id;";

            var id = new SqlParameter ("@Id", conta.Id);

            int registrosAfetados = await _context.Database.ExecuteSqlCommandAsync (
                deleteSQL, id);
        }

        public async Task<Conta> Get (Guid id) {
            Entities.Conta conta = await _context
                .Contas
                .FindAsync (id);

            List<Entities.Credito> creditos = await _context
                .Creditos
                .Where (e => e.IdConta == id)
                .ToListAsync ();

            List<Entities.Debito> debitos = await _context
                .Debitos
                .Where (e => e.IdConta == id)
                .ToListAsync ();

            List<ITransacao> transacoes = new List<ITransacao> ();

            foreach (Entities.Credito dadosTransacao in creditos) {
                Credito transacao = Credito.CarregarDetalhes (
                    dadosTransacao.Id,
                    dadosTransacao.IdConta,
                    dadosTransacao.ValorTransacao,
                    dadosTransacao.DataTransacao,
                    dadosTransacao.ContaOrigemDestino);

                transacoes.Add (transacao);
            }

            foreach (Entities.Debito dadosTransacao in debitos) {
                Debito transacao = Debito.CarregarDetalhes(
                    dadosTransacao.Id,
                    dadosTransacao.IdConta,
                    dadosTransacao.ValorTransacao,
                    dadosTransacao.DataTransacao,
                    dadosTransacao.ContaOrigemDestino);

                transacoes.Add (transacao);
            }

            var orderedTransactions = transacoes.OrderBy (o => o.DataTransacao).ToList ();

            TransacaoCollection transactionCollection = new TransacaoCollection ();
            transactionCollection.Add (orderedTransactions);

            Conta result = Conta.CarregarDetalhes (
                conta.Id,
                conta.IdCliente,
                transactionCollection);

            return result;
        }

        public async Task Update (Conta conta, Credito credito) {
            Entities.Credito creditoEntity = new Entities.Credito {
                IdConta = credito.IdConta,
                ValorTransacao = credito.ValorTransacao,
                Id = credito.Id,
                DataTransacao = credito.DataTransacao,
                ContaOrigemDestino = credito.ContaOrigemDestino
            };

            await _context.Creditos.AddAsync (creditoEntity);
            await _context.SaveChangesAsync ();
        }

        public async Task Update (Conta conta, Debito debito) {
            Entities.Debito debitoEntity = new Entities.Debito {
                IdConta = debito.IdConta,
                ValorTransacao = debito.ValorTransacao,
                Id = debito.Id,
                DataTransacao = debito.DataTransacao,
                ContaOrigemDestino = debito.ContaOrigemDestino
            };

            await _context.Debitos.AddAsync (debitoEntity);
            await _context.SaveChangesAsync ();
        }
    }
}
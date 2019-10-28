namespace AplicacaoBancoExtrato.Domain.Contas {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class TransacaoCollection {
        private readonly IList<ITransacao> _transacoes;

        public TransacaoCollection () {
            _transacoes = new List<ITransacao> ();
        }

        public IReadOnlyCollection<ITransacao> ToReadOnlyCollection () {
            IReadOnlyCollection<ITransacao> transactions = new ReadOnlyCollection<ITransacao> (_transacoes);
            return transactions;
        }

        public ITransacao CopiarUltimaTransacao() {
            ITransacao ultimaTransacao = _transacoes[_transacoes.Count - 1];
            ITransacao copiaDaUltimaTransacao = null;

            if (ultimaTransacao is Credito) {
                copiaDaUltimaTransacao = Credito.CarregarDetalhes (
                    ((Credito) ultimaTransacao).Id,
                    ((Credito) ultimaTransacao).IdConta,
                    ((Credito) ultimaTransacao).ValorTransacao,
                    ((Credito) ultimaTransacao).DataTransacao,
                    ((Credito) ultimaTransacao).ContaOrigemDestino
                );
            }

            if (ultimaTransacao is Debito) {
                copiaDaUltimaTransacao = Debito.CarregarDetalhes (
                    ((Debito) ultimaTransacao).Id,
                    ((Debito) ultimaTransacao).IdConta,
                    ((Debito) ultimaTransacao).ValorTransacao,
                    ((Debito) ultimaTransacao).DataTransacao,
                    ((Debito) ultimaTransacao).ContaOrigemDestino
                );
            }

            return copiaDaUltimaTransacao;
        }

        public void Add (ITransacao transaction) {
            _transacoes.Add (transaction);
        }

        public void Add (IEnumerable<ITransacao> transactions) {
            foreach (var transaction in transactions) {
                Add (transaction);
            }
        }

        public ValorTransacao GetBalance () {
            ValorTransacao balance = 0;

            foreach (ITransacao item in _transacoes) {
                if (item is Debito)
                    balance = balance - item.ValorTransacao;

                if (item is Credito)
                    balance = balance + item.ValorTransacao;
            }

            return balance;
        }
    }
}
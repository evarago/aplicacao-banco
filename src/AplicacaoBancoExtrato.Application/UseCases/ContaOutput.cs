namespace AplicacaoBancoExtrato.Application.UseCases {
    using System.Collections.Generic;
    using System;
    using AplicacaoBancoExtrato.Domain.Contas;

    public sealed class ContaOutput {
        public Guid IdConta { get; }
        public decimal SaldoAtual { get; }
        public List<TransacaoOutput> Transacoes { get; }

        public ContaOutput (
            Guid Id,
            decimal saldoAtual,
            List<TransacaoOutput> transacoes) {
            IdConta = Id;
            SaldoAtual = saldoAtual;
            Transacoes = transacoes;
        }

        public ContaOutput (Conta conta) {
            IdConta = conta.Id;
            SaldoAtual = conta.GetSaldoAtual();

            List<TransacaoOutput> resultadoTransacoes = new List<TransacaoOutput> ();
            foreach (ITransacao transacao in conta.Transacoes.ToReadOnlyCollection ()) {
                TransacaoOutput transacaoOutput = new TransacaoOutput (
                    transacao.Descricao, transacao.ValorTransacao, transacao.DataTransacao, transacao.ContaOrigemDestino);
                resultadoTransacoes.Add (transacaoOutput);
            }

            Transacoes = resultadoTransacoes;
        }
    }
}
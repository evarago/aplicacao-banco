namespace AplicacaoBancoExtrato.WebApi.UseCases {
    using System.Collections.Generic;
    using System;

    public sealed class ContaDetalhesModel {
        public Guid IdConta { get; }
        public decimal SaldoAtual { get; }
        public List<TransacaoModel> Transacoes { get; }

        public ContaDetalhesModel (Guid id, decimal saldoAtual, List<TransacaoModel> transacoes) {
            IdConta = id;
            SaldoAtual = saldoAtual;
            Transacoes = transacoes;
        }
    }
}
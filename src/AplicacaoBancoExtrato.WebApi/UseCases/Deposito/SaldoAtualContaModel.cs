namespace AplicacaoBancoExtrato.WebApi.UseCases.Deposito {
    using System;

    public class SaldoAtualContaModel {
        public decimal ValorTransacao { get; }
        public string Descricao { get; }
        public DateTime DataTransacao { get; }
        public decimal SaldoAtual { get; }
        public string ContaOrigemDestino { get; }

        public SaldoAtualContaModel(
            decimal valorTransacao,
            string descricao,
            DateTime dataTransacao,
            decimal saldoAtual,
            string contaOrigemDestino) {
            ValorTransacao = valorTransacao;
            Descricao = descricao;
            DataTransacao = dataTransacao;
            SaldoAtual = saldoAtual;
            ContaOrigemDestino = contaOrigemDestino;
        }
    }
}
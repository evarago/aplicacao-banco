namespace AplicacaoBancoExtrato.Application.UseCases {
    using System;
    public sealed class TransacaoOutput {
        public string Descricao { get; }
        public decimal ValorTransacao { get; }
        public DateTime DataTransacao { get; }
        public string ContaOrigemDestino { get; }

        public TransacaoOutput(
            string descricao,
            decimal valorTransacao,
            DateTime dataTransacao,
            string contaOrigemDestino) {
            Descricao = descricao;
            ValorTransacao = valorTransacao;
            DataTransacao = dataTransacao;
            ContaOrigemDestino = contaOrigemDestino;
        }
    }
}
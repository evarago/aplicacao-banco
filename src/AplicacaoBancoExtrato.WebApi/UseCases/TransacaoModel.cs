namespace AplicacaoBancoExtrato.WebApi.UseCases {
    using System;

    public sealed class TransacaoModel {
        public decimal ValorTransacao { get; }
        public string Descricao { get; }
        public DateTime DataTransacao { get; }
        public string ContaOrigem { get; }
        public string ContaDestino { get; }
        public TransacaoModel (decimal valorTransacao, string descricao, DateTime dataTransacao, string contaOrigem, string contaDestino) {
            ValorTransacao = valorTransacao;
            Descricao = descricao;
            DataTransacao = dataTransacao;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
        }
    }
}
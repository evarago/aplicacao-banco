namespace AplicacaoBancoExtrato.WebApi.UseCases.Saque
{
    using System;

    public class SaldoAtualModel {
        public decimal ValorTransacao { get; }
        public string Descricao { get; }
        public DateTime DataTransacao { get; }
        public decimal SaldoAtualizado { get; }

        public SaldoAtualModel (decimal valorTransacao, string descricao, DateTime dataTransacao, decimal saldoAtualizado) {
            ValorTransacao = valorTransacao;
            Descricao = descricao;
            DataTransacao = dataTransacao;
            SaldoAtualizado = saldoAtualizado;
        }
    }
}
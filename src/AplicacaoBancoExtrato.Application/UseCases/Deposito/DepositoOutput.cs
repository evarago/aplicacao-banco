namespace AplicacaoBancoExtrato.Application.UseCases.Deposito {
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class DepositoOutput {
        public TransacaoOutput Transacao { get; }
        public decimal SaldoAtualizado { get; }

        public DepositoOutput(
            Credito credito,
            ValorTransacao saldoAtualizado) {
            Transacao = new TransacaoOutput (
                credito.Descricao,
                credito.ValorTransacao,
                credito.DataTransacao,
                credito.ContaOrigemDestino);

            SaldoAtualizado = saldoAtualizado;
        }
    }
}
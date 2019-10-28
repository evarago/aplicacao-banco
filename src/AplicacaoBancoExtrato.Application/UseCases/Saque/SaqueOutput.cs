namespace AplicacaoBancoExtrato.Application.UseCases.Saque
{
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class SaqueOutput {
        public TransacaoOutput Transacao { get; }
        public decimal SaldoAtualizado { get; }

        public SaqueOutput (Debito transacao, ValorTransacao saldoAtualizado, string contaOrigemDestino) {
            Transacao = new TransacaoOutput (
                transacao.Descricao,
                transacao.ValorTransacao,
                transacao.DataTransacao,
                transacao.ContaOrigemDestino);

            SaldoAtualizado = saldoAtualizado;
        }
    }
}
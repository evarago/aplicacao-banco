namespace AplicacaoBancoExtrato.Domain.Contas {
    public sealed class InsuficientFundsException : DomainException {
        internal InsuficientFundsException (string message) : base (message) { }
    }
}
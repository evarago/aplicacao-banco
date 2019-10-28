namespace AplicacaoBancoExtrato.Domain.Contas {
    public sealed class ContaNaoPodeSerFechadaException : DomainException {
        internal ContaNaoPodeSerFechadaException (string message) : base (message) { }
    }
}
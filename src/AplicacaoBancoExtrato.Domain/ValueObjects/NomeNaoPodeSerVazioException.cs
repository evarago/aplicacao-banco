namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    public sealed class NomeNaoPodeSerVazioException : DomainException {
        internal NomeNaoPodeSerVazioException (string message) : base (message) { }
    }
}
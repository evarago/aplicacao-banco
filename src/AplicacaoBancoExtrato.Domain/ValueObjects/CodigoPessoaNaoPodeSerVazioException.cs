namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    public sealed class CodigoPessoaNaoPodeSerVazioException : DomainException {
        internal CodigoPessoaNaoPodeSerVazioException (string message) : base (message) { }
    }
}
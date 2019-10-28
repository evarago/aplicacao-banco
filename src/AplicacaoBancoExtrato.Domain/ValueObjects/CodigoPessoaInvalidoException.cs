namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    internal sealed class CodigoPessoaInvalidoException : DomainException {
        internal CodigoPessoaInvalidoException (string message) : base (message) { }
    }
}
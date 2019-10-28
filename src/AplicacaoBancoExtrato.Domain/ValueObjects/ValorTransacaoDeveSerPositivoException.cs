namespace AplicacaoBancoExtrato.Domain.ValueObjects {
    public sealed class ValorTransacaoDeveSerPositivoException : DomainException {
        internal ValorTransacaoDeveSerPositivoException (string message) : base (message) { }
    }
}
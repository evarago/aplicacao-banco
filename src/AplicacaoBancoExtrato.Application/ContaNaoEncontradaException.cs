namespace AplicacaoBancoExtrato.Application {
    internal sealed class ContaNaoEncontradaException : ApplicationException {
        internal ContaNaoEncontradaException (string message) : base (message) { }
    }
}
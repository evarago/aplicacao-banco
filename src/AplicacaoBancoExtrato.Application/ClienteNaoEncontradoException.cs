namespace AplicacaoBancoExtrato.Application {
    internal sealed class ClienteNaoEncontradoException : ApplicationException {
        internal ClienteNaoEncontradoException (string message) : base (message) { }
    }
}
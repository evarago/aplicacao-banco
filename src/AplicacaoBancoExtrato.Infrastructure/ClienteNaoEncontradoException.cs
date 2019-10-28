namespace AplicacaoBancoExtrato.Infrastructure {
    public class ClienteNaoEncontradoException : InfrastructureException {
        internal ClienteNaoEncontradoException (string message) : base (message) { }
    }
}
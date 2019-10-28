namespace AplicacaoBancoExtrato.Infrastructure {
    public class ContaNaoEncontradaException : InfrastructureException {
        internal ContaNaoEncontradaException (string message) : base (message) { }
    }
}
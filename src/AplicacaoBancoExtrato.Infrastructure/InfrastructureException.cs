namespace AplicacaoBancoExtrato.Infrastructure {
    using System;
    public class InfrastructureException : Exception {
        internal InfrastructureException (string businessMessage) : base (businessMessage) { }
    }
}
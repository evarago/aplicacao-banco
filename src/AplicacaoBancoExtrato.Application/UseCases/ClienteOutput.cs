namespace AplicacaoBancoExtrato.Application.UseCases {
    using System.Collections.Generic;
    using System;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public sealed class ClienteOutput {
        public Guid IdCliente { get; }
        public string Codigo { get; }
        public string Nome { get; }
        public IReadOnlyList<ContaOutput> Contas { get; }

        public ClienteOutput (
            Cliente cliente,
            List<ContaOutput> contas) {
            IdCliente = cliente.Id;
            Codigo = cliente.Codigo;
            Nome = cliente.Nome;
            Contas = contas;
        }
    }
}
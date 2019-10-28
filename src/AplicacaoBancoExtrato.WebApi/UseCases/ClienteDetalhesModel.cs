namespace AplicacaoBancoExtrato.WebApi.UseCases {
    using System.Collections.Generic;
    using System;

    public sealed class ClienteDetalhesModel {
        public Guid IdCliente { get; }
        public string Codigo { get; }
        public string Nome { get; }
        public List<ContaDetalhesModel> Contas { get; }

        public ClienteDetalhesModel (Guid id, string codigo, string nome, List<ContaDetalhesModel> contas) {
            IdCliente = id;
            Codigo = codigo;
            Nome = nome;
            Contas = contas;
        }
    }
}
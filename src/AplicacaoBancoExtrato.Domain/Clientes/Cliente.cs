namespace AplicacaoBancoExtrato.Domain.Clientes {
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class Cliente : IEntity, IAggregateRoot {
        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public CodigoPessoa Codigo { get; private set; }
        public ContaCollection Contas { get; private set; }

        public Cliente (CodigoPessoa codigo, Nome nome) {
            Id = Guid.NewGuid ();
            Codigo = codigo;
            Nome = nome;
            Contas = new ContaCollection ();
        }

        public void Cadastrar (Guid IdConta) {
            Contas.Add (IdConta);
        }

        private Cliente () { }

        public static Cliente CarregarDetalhes (Guid id, Nome nome, CodigoPessoa codigo, ContaCollection contas) {
            Cliente cliente = new Cliente ();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.Codigo = codigo;
            cliente.Contas = contas;
            return cliente;
        }
    }
}
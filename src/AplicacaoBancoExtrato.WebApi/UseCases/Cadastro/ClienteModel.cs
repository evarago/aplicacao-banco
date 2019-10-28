namespace AplicacaoBancoExtrato.WebApi.UseCases.Cadastro
{
    using System.Collections.Generic;
    using System;

    public class ClienteModel {
        public Guid IdCliente { get; }
        public string Codigo { get; }
        public string Nome { get; }
        public List<ContaDetalhesModel> Contas { get; set; }

        public ClienteModel (
            Guid idCliente,
            string codigo,
            string nome,
            List<ContaDetalhesModel> contas) {
            IdCliente = IdCliente;
            Codigo = codigo;
            Nome = nome;
            Contas = contas;
        }
    }
}
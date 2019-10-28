namespace AplicacaoBancoExtrato.WebApi.UseCases.Cadastro {
    using System.Collections.Generic;
    using AplicacaoBancoExtrato.Application.UseCases.Cadastro;
    using Microsoft.AspNetCore.Mvc;

    public class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (CadastroOutput response) {
            if (response == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            List<TransacaoModel> transactions = new List<TransacaoModel> ();

            foreach (var item in response.Conta.Transacoes) {
                var transacao = new TransacaoModel (
                    item.ValorTransacao,
                    item.Descricao,
                    item.DataTransacao,
                    contaOrigem: (item.Descricao.Equals("Crédito") ? item.ContaOrigemDestino : string.Empty),
                    contaDestino: (item.Descricao.Equals("Débito") ? item.ContaOrigemDestino : string.Empty));

                transactions.Add (transacao);
            }

            ContaDetalhesModel conta = new ContaDetalhesModel (
                response.Conta.IdConta,
                response.Conta.SaldoAtual,
                transactions);

            List<ContaDetalhesModel> contas = new List<ContaDetalhesModel> ();
            contas.Add(conta);

            ClienteModel model = new ClienteModel (
                response.Cliente.IdCliente,
                response.Cliente.Codigo,
                response.Cliente.Nome,
                contas
            );

            ViewModel = new CreatedAtRouteResult ("GetCliente", new { idCliente = model.IdCliente }, model);
        }
    }
}
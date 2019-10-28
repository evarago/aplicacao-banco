namespace AplicacaoBancoExtrato.WebApi.UseCases.GetClienteDetalhes
{
    using System.Collections.Generic;
    using AplicacaoBancoExtrato.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    public class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (ClienteOutput output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            List<ContaDetalhesModel> contas = new List<ContaDetalhesModel> ();

            foreach (var conta in output.Contas) {
                List<TransacaoModel> transacoes = new List<TransacaoModel> ();

                foreach (var item in conta.Transacoes) {
                    var transaction = new TransacaoModel (
                        item.ValorTransacao,
                        item.Descricao,
                        item.DataTransacao,
                        contaOrigem: (item.Descricao.Equals("Crédito") ? item.ContaOrigemDestino : string.Empty),
                        contaDestino: (item.Descricao.Equals("Débito") ? item.ContaOrigemDestino : string.Empty));

                    transacoes.Add(transaction);
                }

                contas.Add (new ContaDetalhesModel (
                    conta.IdConta,
                    conta.SaldoAtual,
                    transacoes));
            }

            ClienteDetalhesModel model = new ClienteDetalhesModel (
                output.IdCliente,
                output.Codigo,
                output.Nome,
                contas
            );

            ViewModel = new ObjectResult (model);
        }
    }
}
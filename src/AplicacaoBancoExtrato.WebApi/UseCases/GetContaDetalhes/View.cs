namespace AplicacaoBancoExtrato.WebApi.UseCases.GetContaDetalhes
{
    using System.Collections.Generic;
    using AplicacaoBancoExtrato.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    public sealed class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (ContaOutput output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            List<TransacaoModel> transacoes = new List<TransacaoModel> ();

            foreach (var item in output.Transacoes) {
                var transacao = new TransacaoModel(
                    item.ValorTransacao,
                    item.Descricao,
                    item.DataTransacao,
                    contaOrigem: (item.Descricao.Equals("Crédito") ? item.ContaOrigemDestino : string.Empty),
                    contaDestino: (item.Descricao.Equals("Débito") ? item.ContaOrigemDestino : string.Empty));

                transacoes.Add(transacao);
            }

            ViewModel = new ObjectResult(new ContaDetalhesModel (
                output.IdConta,
                output.SaldoAtual,
                transacoes));
        }
    }
}
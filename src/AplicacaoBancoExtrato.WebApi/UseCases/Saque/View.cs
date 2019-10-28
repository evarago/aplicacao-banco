namespace AplicacaoBancoExtrato.WebApi.UseCases.Saque
{
    using AplicacaoBancoExtrato.Application.UseCases.Saque;
    using Microsoft.AspNetCore.Mvc;

    public class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (SaqueOutput output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            ViewModel = new ObjectResult (new {
                    ValorTransacao = output.Transacao.ValorTransacao,
                    Descricao = output.Transacao.Descricao,
                    DataTransacao = output.Transacao.DataTransacao,
                    SaldoAtualizado = output.SaldoAtualizado,
                    ContaDestino = output.Transacao.ContaOrigemDestino
            });
        }
    }
}
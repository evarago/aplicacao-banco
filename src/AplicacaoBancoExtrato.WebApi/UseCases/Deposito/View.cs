namespace AplicacaoBancoExtrato.WebApi.UseCases.Deposito {
    using AplicacaoBancoExtrato.Application.UseCases.Deposito;
    using Microsoft.AspNetCore.Mvc;

    public class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (DepositoOutput output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            ViewModel = new ObjectResult (new
            {
                ValorTransacao = output.Transacao.ValorTransacao,
                Descricao = output.Transacao.Descricao,
                DataTransacao = output.Transacao.DataTransacao,
                SaldoAtualizado = output.SaldoAtualizado,
                ContaOrigem = output.Transacao.ContaOrigemDestino
            });
        }
    }
}
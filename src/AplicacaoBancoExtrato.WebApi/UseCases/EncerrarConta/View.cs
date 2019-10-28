namespace AplicacaoBancoExtrato.WebApi.UseCases.EncerrarConta
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    public sealed class View {
        public IActionResult ViewModel { get; private set; }

        public void Populate (Guid output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            ViewModel = new OkResult ();
        }
    }
}
namespace AplicacaoBancoExtrato.WebApi.UseCases.EncerrarConta {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.UseCases.EncerraConta;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ContaController : Controller {
        private readonly IEncerraContaUseCase _EncerrarContaUseCase;
        private readonly View _view;

        public ContaController (
            IEncerraContaUseCase EncerrarContaUseCase,
            View presenter) {
            _EncerrarContaUseCase = EncerrarContaUseCase;
            _view = presenter;
        }

        /// <summary>
        /// Encerrar a conta
        /// </summary>
        [HttpDelete ("{IdConta}")]
        public async Task<IActionResult> Close(Guid idConta) {
            Guid output = await _EncerrarContaUseCase.Execute (idConta);
            _view.Populate (output);
            return _view.ViewModel;
        }
    }
}
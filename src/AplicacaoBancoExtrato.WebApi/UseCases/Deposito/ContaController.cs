namespace AplicacaoBancoExtrato.WebApi.UseCases.Deposito {
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Application.UseCases.Deposito;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ContaController : Controller {
        private readonly IDepositoUseCase _depositoUseCase;
        private readonly View _view;

        public ContaController (
            IDepositoUseCase depositoUseCase,
            View view) {
            _depositoUseCase = depositoUseCase;
            _view = view;
        }

        /// <summary>
        /// Deposito na conta
        /// </summary>
        [HttpPatch ("Deposito")]
        public async Task<IActionResult> Deposito([FromBody] DepositoRequest message) {
            var output = await _depositoUseCase.Execute(message.IdConta, message.Valor, message.ContaOrigem);
            _view.Populate(output);
            return _view.ViewModel;
        }
    }
}
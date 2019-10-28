namespace AplicacaoBancoExtrato.WebApi.UseCases.Saque {
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Application.UseCases.Saque;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ContaController : Controller {
        private readonly ISaqueUseCase _saqueUseCase;
        private readonly View _view;

        public ContaController (
            ISaqueUseCase saqueUseCase,
            View view) {
            _saqueUseCase = saqueUseCase;
            _view = view;
        }

        /// <summary>
        /// Saque da conta
        /// </summary>
        [HttpPatch ("Saque")]
        public async Task<IActionResult> Saque([FromBody] SaqueRequest request) {
            SaqueOutput output = await _saqueUseCase.Execute(request.IdConta, request.ValorTransacao, request.ContaDestino);
            _view.Populate(output);
            return _view.ViewModel;
        }
    }
}
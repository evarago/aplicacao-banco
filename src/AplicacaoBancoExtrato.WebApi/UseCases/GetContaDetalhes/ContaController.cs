namespace AplicacaoBancoExtrato.WebApi.UseCases.GetContaDetalhes
{
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.UseCases.GetContaDetalhes;
    using AplicacaoBancoExtrato.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ContaController : Controller {
        private readonly IGetContaDetalhesUseCase _getContaDetalhesUseCase;
        private readonly View _view;

        public ContaController (
            IGetContaDetalhesUseCase getContaDetalhesUseCase,
            View view) {
            _getContaDetalhesUseCase = getContaDetalhesUseCase;
            _view = view;
        }

        /// <summary>
        /// Obter dados da conta
        /// </summary>
        [HttpGet ("{idConta}", Name = "GetConta")]
        public async Task<IActionResult> Get(Guid idConta) {
            ContaOutput output = await _getContaDetalhesUseCase.Execute(idConta);
            _view.Populate (output);
            return _view.ViewModel;
        }
    }
}
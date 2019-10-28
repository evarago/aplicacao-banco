namespace AplicacaoBancoExtrato.WebApi.UseCases.GetClienteDetalhes
{
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.UseCases.GetClienteDetalhes;
    using AplicacaoBancoExtrato.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ClienteController : Controller {
        private readonly IGetClienteDetalhesUseCase _getClienteDetalhesUseCase;
        private readonly View _view;

        public ClienteController (
            IGetClienteDetalhesUseCase getClienteDetalhesUseCase,
            View view) {
            _getClienteDetalhesUseCase = getClienteDetalhesUseCase;
            _view = view;
        }

        /// <summary>
        /// Obter dados do cliente
        /// </summary>
        [HttpGet ("{idCliente}", Name = "GetCliente")]
        public async Task<IActionResult> GetCliente(Guid idCliente) {
            ClienteOutput output = await _getClienteDetalhesUseCase.Execute (idCliente);
            _view.Populate (output);
            return _view.ViewModel;
        }
    }
}
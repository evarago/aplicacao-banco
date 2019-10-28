namespace AplicacaoBancoExtrato.WebApi.UseCases.Cadastro {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Application.UseCases.Cadastro;
    using AplicacaoBancoExtrato.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class ClienteController : Controller {
        private readonly ICadastroUseCase _cadastroUseCase;
        private readonly View _view;

        public ClienteController (
            ICadastroUseCase cadastroUseCase,
            View view) {
            _cadastroUseCase = cadastroUseCase;
            _view = view;
        }

        /// <summary>
        /// Cadastro de novo cliente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroRequest request) {
            CadastroOutput output = await _cadastroUseCase.Execute (
                request.Codigo,
                request.Nome,
                request.ValorInicial,
                "xxxx");

            _view.Populate(output);
            return _view.ViewModel;
        }
    }
}
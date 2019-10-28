namespace AplicacaoBancoExtrato.Application.UseCases.GetContaDetalhes
{
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;

    public sealed class GetContaDetalhesUseCase : IGetContaDetalhesUseCase {
        private readonly IContaReadOnlyRepository _contaReadOnlyRepository;

        public GetContaDetalhesUseCase (IContaReadOnlyRepository contaReadOnlyRepository) {
            _contaReadOnlyRepository = contaReadOnlyRepository;
        }

        public async Task<ContaOutput> Execute (Guid idConta) {
            Conta conta = await _contaReadOnlyRepository.Get(idConta);

            if (conta == null)
                throw new ContaNaoEncontradaException ($"A conta {idConta} não existe ou não foi processada ainda.");

            ContaOutput output = new ContaOutput (conta);
            return output;
        }
    }
}
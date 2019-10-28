namespace AplicacaoBancoExtrato.Application.UseCases.EncerraConta
{
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;

    public sealed class EncerraContaUseCase : IEncerraContaUseCase {
        private readonly IContaReadOnlyRepository _contaReadOnlyRepository;
        private readonly IContaWriteOnlyRepository _contaWriteOnlyRepository;

        public EncerraContaUseCase(
            IContaReadOnlyRepository contaReadOnlyRepository,
            IContaWriteOnlyRepository contaWriteOnlyRepository) {
            _contaReadOnlyRepository = contaReadOnlyRepository;
            _contaWriteOnlyRepository = contaWriteOnlyRepository;
        }

        public async Task<Guid> Execute (Guid idConta) {
            Conta conta = await _contaReadOnlyRepository.Get(idConta);
            if (conta== null)
                throw new ContaNaoEncontradaException ($"A conta {idConta} não existe ou foi encerrada.");

            conta.Fecha();

            await _contaWriteOnlyRepository.Delete (conta);

            return conta.Id;
        }
    }
}
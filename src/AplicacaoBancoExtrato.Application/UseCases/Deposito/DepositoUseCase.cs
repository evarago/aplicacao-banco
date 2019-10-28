namespace AplicacaoBancoExtrato.Application.UseCases.Deposito {
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class DepositoUseCase : IDepositoUseCase {
        private readonly IContaReadOnlyRepository _contaReadOnlyRepository;
        private readonly IContaWriteOnlyRepository _contaWriteOnlyRepository;

        public DepositoUseCase (
            IContaReadOnlyRepository contaReadOnlyRepository,
            IContaWriteOnlyRepository contaWriteOnlyRepository) {
            _contaReadOnlyRepository = contaReadOnlyRepository;
            _contaWriteOnlyRepository = contaWriteOnlyRepository;
        }

        public async Task<DepositoOutput> Execute (Guid idConta, ValorTransacao valorTransacao, string contaOrigem) {
            Conta conta = await _contaReadOnlyRepository.Get (idConta);
            if (conta == null)
                throw new ContaNaoEncontradaException ($"A conta {idConta} não existe ou foi encerrada.");

            conta.Deposito(valorTransacao, contaOrigem);
            Credito credito = (Credito)conta.GetultimaTransacao();

            await _contaWriteOnlyRepository.Update(conta, credito);

            DepositoOutput output = new DepositoOutput (
                credito,
                conta.GetSaldoAtual ());
            return output;
        }
    }
}
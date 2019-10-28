namespace AplicacaoBancoExtrato.Application.UseCases.Saque
{
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class SaqueUseCase : ISaqueUseCase {
        private readonly IContaReadOnlyRepository _contaReadOnlyRepository;
        private readonly IContaWriteOnlyRepository _contaWriteOnlyRepository;

        public SaqueUseCase (
            IContaReadOnlyRepository contaReadOnlyRepository,
            IContaWriteOnlyRepository contaWriteOnlyRepository) {
            _contaReadOnlyRepository = contaReadOnlyRepository;
            _contaWriteOnlyRepository = contaWriteOnlyRepository;
        }

        public async Task<SaqueOutput> Execute (Guid idConta, ValorTransacao valorTransacao, string contaDestino) {
            Conta conta = await _contaReadOnlyRepository.Get(idConta);
            if (conta == null)
                throw new ContaNaoEncontradaException ($"A conta {idConta} não existe ou foi encerrada.");

            conta.Saque(valorTransacao, contaDestino);
            Debito debito = (Debito)conta.GetultimaTransacao();

            await _contaWriteOnlyRepository.Update(conta, debito);

            SaqueOutput output = new SaqueOutput (
                debito,
                conta.GetSaldoAtual(),
                debito.ContaOrigemDestino
            );

            return output;
        }
    }
}
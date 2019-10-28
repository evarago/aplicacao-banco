namespace AplicacaoBancoExtrato.Application.UseCases.GetClienteDetalhes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.Clientes;

    public sealed class GetClienteDetalhesUseCase : IGetClienteDetalhesUseCase {
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;
        private readonly IContaReadOnlyRepository _contaReadOnlyRepository;

        public GetClienteDetalhesUseCase (
            IClienteReadOnlyRepository clienteReadOnlyRepository,
            IContaReadOnlyRepository contaReadOnlyRepository) {
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
            _contaReadOnlyRepository = contaReadOnlyRepository;
        }

        public async Task<ClienteOutput> Execute (Guid idCliente) {
            Cliente customer = await _clienteReadOnlyRepository.Get (idCliente);

            if (customer == null)
                throw new ClienteNaoEncontradoException ($"O cliente {idCliente} não existe ou não foi processado ainda.");

            List<ContaOutput> contas = new List<ContaOutput> ();

            foreach (Guid accountId in customer.Contas.ToReadOnlyCollection ()) {
                Conta conta = await _contaReadOnlyRepository.Get (accountId);

                if (conta != null) {
                    ContaOutput contaOutput = new ContaOutput (conta);
                    contas.Add (contaOutput);
                }
            }

            ClienteOutput output = new ClienteOutput (customer, contas);
            return output;
        }
    }
}
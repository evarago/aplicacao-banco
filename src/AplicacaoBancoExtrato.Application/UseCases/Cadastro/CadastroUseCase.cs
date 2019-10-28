namespace AplicacaoBancoExtrato.Application.UseCases.Cadastro
{
    using System.Threading.Tasks;
    using AplicacaoBancoExtrato.Application.Repositories;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.Clientes;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class CadastroUseCase : ICadastroUseCase {
        private readonly IClienteWriteOnlyRepository _clienteWriteOnlyRepository;
        private readonly IContaWriteOnlyRepository _contatWriteOnlyRepository;

        public CadastroUseCase (
            IClienteWriteOnlyRepository clienteWriteOnlyRepository,
            IContaWriteOnlyRepository contaWriteOnlyRepository) {
            _clienteWriteOnlyRepository = clienteWriteOnlyRepository;
            _contatWriteOnlyRepository = contaWriteOnlyRepository;
        }

        public async Task<CadastroOutput> Execute (CodigoPessoa codigo, Nome nome, ValorTransacao valorInicial, string contaOrigem) {
            Cliente cliente = new Cliente(codigo, nome);

            Conta conta = new Conta (cliente.Id);
            conta.Deposito(valorInicial, contaOrigem);
            Credito credito = (Credito) conta.GetultimaTransacao();

            cliente.Cadastrar (conta.Id);

            await _clienteWriteOnlyRepository.Add (cliente);
            await _contatWriteOnlyRepository.Add (conta, credito);

            CadastroOutput output = new CadastroOutput (cliente, conta);
            return output;
        }
    }
}
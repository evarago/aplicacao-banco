namespace AplicacaoBancoExtrato.Application.UseCases.GetClienteDetalhes
{
    using System.Threading.Tasks;
    using System;

    public interface IGetClienteDetalhesUseCase {
        Task<ClienteOutput> Execute (Guid idCliente);
    }
}
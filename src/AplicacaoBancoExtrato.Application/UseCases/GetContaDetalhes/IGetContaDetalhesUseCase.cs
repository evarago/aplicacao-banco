namespace AplicacaoBancoExtrato.Application.UseCases.GetContaDetalhes
{
    using System.Threading.Tasks;
    using System;

    public interface IGetContaDetalhesUseCase {
        Task<ContaOutput> Execute (Guid idConta);
    }
}
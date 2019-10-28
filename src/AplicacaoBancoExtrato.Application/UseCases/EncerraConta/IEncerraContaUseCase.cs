namespace AplicacaoBancoExtrato.Application.UseCases.EncerraConta
{
    using System.Threading.Tasks;
    using System;

    public interface IEncerraContaUseCase
    {
        Task<Guid> Execute (Guid idConta);
    }
}
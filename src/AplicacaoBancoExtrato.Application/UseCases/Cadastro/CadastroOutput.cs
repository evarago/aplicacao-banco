namespace AplicacaoBancoExtrato.Application.UseCases.Cadastro
{
    using System.Collections.Generic;
    using AplicacaoBancoExtrato.Domain.Contas;
    using AplicacaoBancoExtrato.Domain.Clientes;
    using System;

    public sealed class CadastroOutput {
        public ClienteOutput Cliente { get; }
        public ContaOutput Conta { get; }

        public CadastroOutput (Cliente cliente, Conta conta) {
            try
            {
                List<TransacaoOutput> transacoes = new List<TransacaoOutput>();

                foreach (ITransacao transacao in conta.Transacoes.ToReadOnlyCollection())
                {
                    transacoes.Add(
                        new TransacaoOutput(
                            transacao.Descricao,
                            transacao.ValorTransacao,
                            transacao.DataTransacao,
                            transacao.ContaOrigemDestino));
                }

                Conta = new ContaOutput(conta.Id, conta.GetSaldoAtual(), transacoes);

                List<ContaOutput> accountOutputs = new List<ContaOutput>();
                accountOutputs.Add(Conta);

                Cliente = new ClienteOutput(cliente, accountOutputs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
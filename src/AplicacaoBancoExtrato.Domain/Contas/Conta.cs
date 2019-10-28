namespace AplicacaoBancoExtrato.Domain.Contas {
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class Conta : IEntity, IAggregateRoot {
        public Guid Id { get; private set; }
        public Guid IdCliente { get; private set; }
        public TransacaoCollection Transacoes { get; private set; }

        public Conta (Guid customerId) {
            Id = Guid.NewGuid ();
            IdCliente = customerId;
            Transacoes = new TransacaoCollection ();
        }

        public void Deposito (ValorTransacao ValorTransacao, string contaOrigemDestino) {
            Credito credito = new Credito (Id, ValorTransacao, contaOrigemDestino);
            Transacoes.Add (credito);
        }

        public void Saque (ValorTransacao ValorTransacao, string contaOrigemDestino) {
            ValorTransacao balance = Transacoes.GetBalance ();

            if (balance < ValorTransacao)
                throw new InsuficientFundsException (
                    $"A conta {Id} não tem saldo suficiente para no valor de: {ValorTransacao}. Saldo atual: {balance}.");

            Debito debit = new Debito(Id, ValorTransacao, contaOrigemDestino);
            Transacoes.Add (debit);
        }

        public void Fecha () {
            ValorTransacao balance = Transacoes.GetBalance ();

            if (balance > 0)
                throw new ContaNaoPodeSerFechadaException (
                    $"A conta {Id} não pode ser encerrada pois o saldo é positivo. Saldo atual: {balance}.");
        }

        public ValorTransacao GetSaldoAtual () {
            ValorTransacao balance = Transacoes.GetBalance ();
            return balance;
        }

        public ITransacao GetultimaTransacao () {
            ITransacao ultimaTransacao = Transacoes.CopiarUltimaTransacao();
            return ultimaTransacao;
        }

        private Conta () { }

        public static Conta CarregarDetalhes(Guid id, Guid IdCliente, TransacaoCollection transacoes) {
            Conta conta = new Conta ();
            conta.Id = id;
            conta.IdCliente = IdCliente;
            conta.Transacoes = transacoes;
            return conta;
        }
    }
}
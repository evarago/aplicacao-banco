namespace AplicacaoBancoExtrato.Domain.Contas {
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class Credito : IEntity, ITransacao {
        public Guid Id { get; private set; }
        public Guid IdConta { get; private set; }
        public ValorTransacao ValorTransacao { get; private set; }
        public string ContaOrigemDestino { get; private set; }
        public string Descricao {
            get { return "Crédito"; }
        }
        public DateTime DataTransacao { get; private set; }

        private Credito() { }

        public static Credito CarregarDetalhes(Guid id, Guid idConta, ValorTransacao valorTransacao, DateTime dataTransacao, string contaOrigemDestino) {
            Credito credito = new Credito();
            credito.Id = id;
            credito.IdConta = idConta;
            credito.ValorTransacao = valorTransacao;
            credito.DataTransacao = dataTransacao;
            credito.ContaOrigemDestino = contaOrigemDestino;
            return credito;
        }

        public Credito (Guid idConta, ValorTransacao valorTransacao, string contaOrigemDestino) {
            Id = Guid.NewGuid ();
            IdConta = idConta;
            ValorTransacao = valorTransacao;
            DataTransacao = DateTime.UtcNow;
            ContaOrigemDestino = contaOrigemDestino;
        }
    }
}
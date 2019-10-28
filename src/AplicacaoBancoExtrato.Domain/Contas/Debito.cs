namespace AplicacaoBancoExtrato.Domain.Contas {
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public sealed class Debito : IEntity, ITransacao {
        public Guid Id { get; private set; }
        public Guid IdConta { get; private set; }
        public ValorTransacao ValorTransacao { get; private set; }
        public string ContaOrigemDestino { get; private set; }
        public string Descricao {
            get { return "Débito"; }
        }
        public DateTime DataTransacao { get; private set; }

        private Debito () { }

        public static Debito CarregarDetalhes (Guid id, Guid idConta, ValorTransacao valorTransacao, DateTime dataTransacao, string contaOrigemDestino) {
            Debito debito = new Debito ();
            debito.Id = id;
            debito.IdConta = idConta;
            debito.ValorTransacao = valorTransacao;
            debito.DataTransacao = dataTransacao;
            debito.ContaOrigemDestino = contaOrigemDestino;
            return debito;
        }

        public Debito (Guid idConta, ValorTransacao valorTransacao, string contaOrigemDestino) {
            Id = Guid.NewGuid();
            IdConta = idConta;
            ValorTransacao = valorTransacao;
            DataTransacao = DateTime.UtcNow;
            ContaOrigemDestino = contaOrigemDestino;
        }
    }
}
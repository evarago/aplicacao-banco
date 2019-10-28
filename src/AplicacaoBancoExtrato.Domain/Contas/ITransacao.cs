namespace AplicacaoBancoExtrato.Domain.Contas {
    using System;
    using AplicacaoBancoExtrato.Domain.ValueObjects;

    public interface ITransacao {
        ValorTransacao ValorTransacao { get; }
        string Descricao { get; }
        DateTime DataTransacao { get; }
        string ContaOrigemDestino { get; }
    }
}
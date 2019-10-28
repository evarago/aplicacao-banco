namespace AplicacaoBancoExtrato.WebApi.UseCases.Deposito {
    using System;
    public class DepositoRequest {
        public Guid IdConta { get; set; }
        public decimal Valor { get; set; }
        public string ContaOrigem { get; set; }
    }
}
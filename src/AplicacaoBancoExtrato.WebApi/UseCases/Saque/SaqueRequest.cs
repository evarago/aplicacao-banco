namespace AplicacaoBancoExtrato.WebApi.UseCases.Saque
{
    using System;
    public class SaqueRequest {
        public Guid IdConta { get; set; }
        public decimal ValorTransacao { get; set; }
        public string ContaDestino { get; set; }
    }
}
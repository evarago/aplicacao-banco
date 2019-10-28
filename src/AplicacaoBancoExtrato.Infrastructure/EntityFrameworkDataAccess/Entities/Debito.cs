namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess.Entities {
    using System;

    public class Debito {
        public Guid Id { get; set; }
        public Guid IdConta { get; set; }
        public decimal ValorTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public string ContaOrigemDestino { get; set; }
    }
}
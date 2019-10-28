namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess.Entities {
    using System;

    public class Conta {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
    }
}
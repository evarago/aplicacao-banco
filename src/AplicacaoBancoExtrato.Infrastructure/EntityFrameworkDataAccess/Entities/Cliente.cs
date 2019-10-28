namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess.Entities {
    using System;

    public class Cliente {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
namespace AplicacaoBancoExtrato.Infrastructure.EntityFrameworkDataAccess {
    using Microsoft.EntityFrameworkCore;
    using Entities;
    public sealed class AplicacaoBancoExtratoContext : DbContext {
        public AplicacaoBancoExtratoContext (DbContextOptions options) : base (options) {

        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Debito> Debitos { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Conta> ()
                .ToTable ("Conta");

            modelBuilder.Entity<Cliente> ()
                .ToTable ("Cliente");

            modelBuilder.Entity<Debito> ()
                .ToTable ("Debito");

            modelBuilder.Entity<Credito> ()
                .ToTable ("Credito");
        }
    }
}
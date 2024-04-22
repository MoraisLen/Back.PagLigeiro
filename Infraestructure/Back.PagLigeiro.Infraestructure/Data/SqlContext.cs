using Back.PagLigeiro.Domain.Model.Boleto;
using Back.PagLigeiro.Domain.Model.Cliente;
using Back.PagLigeiro.Domain.Model.Servico;
using Back.PagLigeiro.Domain.Model.User;
using Microsoft.EntityFrameworkCore;

namespace Back.PagLigeiro.Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicoModel>()
                .HasOne(b => b.User)
                .WithMany(a => a.Servicos)
                .HasForeignKey(b => b.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClienteModel>()
                .HasOne(b => b.User)
                .WithMany(a => a.Clientes)
                .HasForeignKey(b => b.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BoletoModel>()
                .HasOne(b => b.Cliente)
                .WithMany(a => a.Boletos)
                .HasForeignKey(b => b.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BoletoModel>()
                .HasOne(b => b.Servico)
                .WithMany(a => a.Boletos)
                .HasForeignKey(b => b.IdServico)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<BoletoModel> Boletos { get; set; }
    }
}
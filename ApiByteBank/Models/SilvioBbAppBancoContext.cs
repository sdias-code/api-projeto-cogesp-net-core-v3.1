using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class SilvioBbAppBancoContext : DbContext
    {
        public SilvioBbAppBancoContext()
        {
        }

        public SilvioBbAppBancoContext(DbContextOptions<SilvioBbAppBancoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<TipoTransaco> TipoTransacoes { get; set; }
        public virtual DbSet<Transaco> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=S1189;Initial Catalog=SilvioBbAppBanco;User Id=axel; Password=axel123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasIndex(e => e.ClienteId, "IX_Contas_ClienteId");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transaco>(entity =>
            {
                entity.HasIndex(e => e.ContaId, "IX_Transacoes_ContaId");

                entity.HasIndex(e => e.TipoTransacaoId, "IX_Transacoes_TipoTransacaoId");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.Transacos)
                    .HasForeignKey(d => d.ContaId);

                entity.HasOne(d => d.TipoTransacao)
                    .WithMany(p => p.Transacos)
                    .HasForeignKey(d => d.TipoTransacaoId);                    
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

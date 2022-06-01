using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class AppBancoContext : DbContext
    {
        public AppBancoContext()
        {
        }

        public AppBancoContext(DbContextOptions<AppBancoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<TipoTransaco> TipoTransacoes { get; set; }
        public virtual DbSet<Transaco> Transacoes { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

             modelBuilder.Entity<Conta>()
            .HasDiscriminator<Enums.ETiposContas>("TipoConta")
            .HasValue<ContaCorrente>(Enums.ETiposContas.ContaCorrente)
            .HasValue<ContaPoupanca>(Enums.ETiposContas.ContaPoupanca)
            .HasValue<ContaSalario>(Enums.ETiposContas.ContaSalario);

        }
    }
}
using Core.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Core.Context
{
    public class GtiContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EnderecoCliente> EnderecoCliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CONNECTION"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(c => c.TipoSexo).HasConversion(typeof(string));
            modelBuilder.Entity<Cliente>()
                .Property(c => c.TipoEstadoCivil).HasConversion(typeof(string));
            base.OnModelCreating(modelBuilder);
        }
    }
}

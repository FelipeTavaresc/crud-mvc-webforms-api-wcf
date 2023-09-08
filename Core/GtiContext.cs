using Core.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class GtiContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EnderecoCliente> EnderecoCliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DB_GTI;MultipleActiveResultSets=True;User Id=sa;Pooling=true;Min Pool Size=1;Max Pool Size=60;Password=Madis@22");
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

using aadrovez.Dominio.Entities;
using System.Data.Entity;

namespace aadrovez.Infraestructura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=stringConexion")
        { }

        public DbSet<TablaCodigo> TablaCondigo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablaCodigo>()
                .Property(e => e.Codigo)
                .IsUnicode(false);
            modelBuilder.Entity<TablaCodigo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}

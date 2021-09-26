using Microsoft.EntityFrameworkCore;
using WebApplication5.Model;

namespace WebApplication5.Context
{
    public class PessoaContext : DbContext
    {
        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<CEPModel> Endereco { get; set; }

        public PessoaContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaModel>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CEPModel>()
               .HasKey(p => p.Id);
            modelBuilder.Entity<CEPModel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

    }
}

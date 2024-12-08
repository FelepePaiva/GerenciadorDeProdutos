using GerenciadorDeProdutos.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Contexts
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        { }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colaborador>().HasData(
            new Colaborador
            {
                Id = 1,
                Nome = "Felepe",
                Email = "felepe@gmail.com",
                Password = "12345",
                Cargo = "Gerente"
            });
            modelBuilder.Entity<Produto>().HasData(
            new Produto
            {
                Id = 1,
                Nome = "Iphone",
                Descricao = "16ProMax",
                StatusProduto = Status.EmEstoque,
                Preco = 10.000m,
                QuantidadeEstoque = 4
            });
        }
    }
}

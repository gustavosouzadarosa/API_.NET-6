using Domain.Entities;
using Infra.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DataBaseContext : DbContext
    {     
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fornecedor>(new FornecedorMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.Mapper
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto")
                   .HasKey(prop => prop.Codigo);

            builder.HasOne(prop => prop.Fornecedor)
                   .WithMany(prop => prop.Produtos)
                   .HasForeignKey(prop => prop.FornecedorCodigo);

            builder.Property(prop => prop.Codigo)
                   .ValueGeneratedOnAdd();

            builder.Property(prop => prop.DataFabricacao)
                   .HasColumnName("DtFabricacao");

            builder.Property(prop => prop.DataValidade)
                   .HasColumnName("DtValidade");
        }
    }
}

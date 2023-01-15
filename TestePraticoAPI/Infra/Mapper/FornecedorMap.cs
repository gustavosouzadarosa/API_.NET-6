using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Mapper
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor")
                   .HasKey(prop => prop.Codigo);

            builder.Property(prop => prop.Codigo)
                   .ValueGeneratedOnAdd();
        }
    }
}

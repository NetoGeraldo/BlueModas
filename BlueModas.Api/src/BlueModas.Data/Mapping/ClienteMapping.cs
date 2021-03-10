using BlueModas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.Data.Mapping
{
    class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("telefone")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);

        }
    }
}

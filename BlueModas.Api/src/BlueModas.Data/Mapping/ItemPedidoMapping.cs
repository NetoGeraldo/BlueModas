using BlueModas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.Data.Mapping
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("itens_pedidos");

            builder.HasKey(ip => new { ip.PedidoId, ip.ProdutoId });
            
            builder.Property(ip => ip.Nome)
                .IsRequired();

            builder.Property(ip => ip.Quantidade)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(ip => ip.ValorUnitario)
                .HasColumnName("valor_unitario")
                .HasPrecision(12,2)
                .IsRequired();

            builder.HasOne(ip => ip.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(ip => ip.PedidoId);

        }
    }
}

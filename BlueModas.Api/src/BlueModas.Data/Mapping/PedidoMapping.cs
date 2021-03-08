using BlueModas.Data.Converters;
using BlueModas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Data.Mapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ValorTotal)
                .HasColumnName("valor_total")
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .HasColumnType("char")
                .HasConversion(new EnumToCharConverter<EStatusPedido>())
                .HasDefaultValue(EStatusPedido.Rascunho)
                .IsRequired();

            builder.Property(p => p.DataFinalizacao)
                .HasColumnName("data_finalizacao");

            builder.HasMany(p => p.ItensPedido)
                .WithOne(ip => ip.Pedido)
                .HasForeignKey(ip => ip.PedidoId);
        }
    }
}

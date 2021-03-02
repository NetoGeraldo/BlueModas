using BlueModas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
                .HasColumnName("imagem");

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .HasPrecision(12, 2);
                
        }
    }
}

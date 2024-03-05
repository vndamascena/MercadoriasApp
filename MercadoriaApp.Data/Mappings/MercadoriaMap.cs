using MercadoriaApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaApp.Data.Mappings
{
    internal class MercadoriaMap : IEntityTypeConfiguration<Mercadorias>
    {
        public void Configure(EntityTypeBuilder<Mercadorias> builder)
        {
            builder.ToTable("MERCADORIA");



            builder.Property(m => m.Id)
                .HasColumnName("ID");

            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Preco)
               .HasColumnName("PRECO")
               .HasColumnType("DECIMAL(10,2)")
               .IsRequired();

            builder.Property(m => m.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(m => m.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired();

            builder.Property(m => m.FornecedorId)
                .HasColumnName("FORNECEADOR_ID")
                .IsRequired();

            //mapeamento do relacionamento Produto com Categoria (1pN)
            builder.HasOne(p => p.Categoria) //Produto TEM 1 Categoria
                .WithMany(c => c.Mercadorias) //Categoria TEM MUITOS produtos
                .HasForeignKey(p => p.CategoriaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.NoAction);

            //mapeamento do relacionamento Produto com Fornecedor
            builder.HasOne(p => p.Fornecedor) //Produto TEM 1 Fornecedor
                .WithMany(f => f.Mercadorias) //Fornecedor TEM MUITOS Produtos
                .HasForeignKey(p => p.FornecedorId) //Chave estrangeira
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}

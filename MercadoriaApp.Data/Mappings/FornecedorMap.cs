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
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            //nome da tabela
            builder.ToTable("FORNECEDOR");

            //campo chave primária
            builder.HasKey(f => f.Id);

            //mapeamento do campo 'Id'
            builder.Property(f => f.Id)
                .HasColumnName("ID");

            //mapeamento do campo 'Razaosocial'
            builder.Property(f => f.RazaoSocial)
               .HasColumnName("RAZAOSOCIAL")
               .HasMaxLength(100)
               .IsRequired();

            //mapeamento do campo 'Cnpj'
            builder.Property(f => f.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(20)
                .IsRequired();


            //definindo o campo 'Nome' como único
            builder.HasIndex(f => f.Cnpj)
                .IsUnique();

        }
    }
}

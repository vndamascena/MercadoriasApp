﻿// <auto-generated />
using System;
using MercadoriaApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MercadoriaApp.Data.Migrations
{
    [DbContext(typeof(DataContexts))]
    partial class DataContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Categoria", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Fornecedor", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("RAZAOSOCIAL");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("FORNECEDOR", (string)null);
                });

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Mercadorias", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid?>("CategoriaId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CATEGORIA_ID");

                    b.Property<Guid?>("FornecedorId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FORNECEADOR_ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnName("PRECO");

                    b.Property<int?>("Quantidade")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADE");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("MERCADORIA", (string)null);
                });

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Mercadorias", b =>
                {
                    b.HasOne("MercadoriaApp.Data.Entities.Categoria", "Categoria")
                        .WithMany("Mercadorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MercadoriaApp.Data.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Mercadorias")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Categoria", b =>
                {
                    b.Navigation("Mercadorias");
                });

            modelBuilder.Entity("MercadoriaApp.Data.Entities.Fornecedor", b =>
                {
                    b.Navigation("Mercadorias");
                });
#pragma warning restore 612, 618
        }
    }
}

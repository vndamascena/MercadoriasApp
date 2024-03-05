﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoriaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MERCADORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRECO = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    CATEGORIA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FORNECEADOR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCADORIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MERCADORIA_CATEGORIA_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MERCADORIA_FORNECEDOR_FORNECEADOR_ID",
                        column: x => x.FORNECEADOR_ID,
                        principalTable: "FORNECEDOR",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_NOME",
                table: "CATEGORIA",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDOR_CNPJ",
                table: "FORNECEDOR",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_CATEGORIA_ID",
                table: "MERCADORIA",
                column: "CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_FORNECEADOR_ID",
                table: "MERCADORIA",
                column: "FORNECEADOR_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MERCADORIA");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "FORNECEDOR");
        }
    }
}

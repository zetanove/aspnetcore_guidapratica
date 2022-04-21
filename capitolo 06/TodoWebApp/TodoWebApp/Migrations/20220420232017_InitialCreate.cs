using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    IDUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.IDUtente);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    IDTodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promemoria = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completata = table.Column<bool>(type: "bit", nullable: false),
                    IDCategoria = table.Column<int>(type: "int", nullable: true),
                    IDUtente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.IDTodo);
                    table.ForeignKey(
                        name: "FK_Todo_Categorie_IDCategoria",
                        column: x => x.IDCategoria,
                        principalTable: "Categorie",
                        principalColumn: "IDCategoria");
                    table.ForeignKey(
                        name: "FK_Todo_Utenti_IDUtente",
                        column: x => x.IDUtente,
                        principalTable: "Utenti",
                        principalColumn: "IDUtente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_IDCategoria",
                table: "Todo",
                column: "IDCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_IDUtente",
                table: "Todo",
                column: "IDUtente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}

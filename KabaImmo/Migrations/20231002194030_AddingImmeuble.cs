using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KabaImmo.Migrations
{
    /// <inheritdoc />
    public partial class AddingImmeuble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeAdresse = table.Column<int>(type: "integer", nullable: false),
                    Employeur = table.Column<string>(type: "text", nullable: true),
                    Adresse1 = table.Column<string>(type: "text", nullable: true),
                    Adresse2 = table.Column<string>(type: "text", nullable: true),
                    Batiment = table.Column<string>(type: "text", nullable: true),
                    Escalier = table.Column<string>(type: "text", nullable: true),
                    Etage = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Ville = table.Column<string>(type: "text", nullable: true),
                    CodePostal = table.Column<string>(type: "text", nullable: true),
                    Pays = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Immeuble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AdresseId = table.Column<Guid>(type: "uuid", nullable: true),
                    Superficie = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immeuble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Immeuble_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Immeuble_AdresseId",
                table: "Immeuble",
                column: "AdresseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Immeuble");

            migrationBuilder.DropTable(
                name: "Adresse");
        }
    }
}

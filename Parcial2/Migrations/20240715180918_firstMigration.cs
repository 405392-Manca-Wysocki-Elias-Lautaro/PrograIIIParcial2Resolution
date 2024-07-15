using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albanile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albanile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposObras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposObras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatosVarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoObra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoObraNavigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obra_TiposObras_IdTipoObraNavigationId",
                        column: x => x.IdTipoObraNavigationId,
                        principalTable: "TiposObras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbanilesXObra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlbanil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdObra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TareaArealizar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdAlbanilNavigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdObraNavigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbanilesXObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbanilesXObra_Albanile_IdAlbanilNavigationId",
                        column: x => x.IdAlbanilNavigationId,
                        principalTable: "Albanile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbanilesXObra_Obra_IdObraNavigationId",
                        column: x => x.IdObraNavigationId,
                        principalTable: "Obra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbanilesXObra_IdAlbanilNavigationId",
                table: "AlbanilesXObra",
                column: "IdAlbanilNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbanilesXObra_IdObraNavigationId",
                table: "AlbanilesXObra",
                column: "IdObraNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Obra_IdTipoObraNavigationId",
                table: "Obra",
                column: "IdTipoObraNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbanilesXObra");

            migrationBuilder.DropTable(
                name: "Albanile");

            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "TiposObras");
        }
    }
}

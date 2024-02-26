using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoADIS.Migrations
{
    /// <inheritdoc />
    public partial class Cursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(80)", nullable: false),
                    FechaHora_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHora_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Requisito = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Usuarios_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ProfesorId",
                table: "Cursos",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}

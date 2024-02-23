using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoADIS.Migrations
{
    /// <inheritdoc />
    public partial class CHECK_COLUMN_TYPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CambioContrasena",
                table: "Usuarios",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CambioContrasena",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)");
        }
    }
}

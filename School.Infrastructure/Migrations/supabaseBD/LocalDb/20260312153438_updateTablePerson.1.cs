using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations.LocalDb
{
    /// <inheritdoc />
    public partial class updateTablePerson1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechanNacimiento",
                table: "Persona",
                newName: "FechaNacimiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Persona",
                newName: "FechanNacimiento");
        }
    }
}

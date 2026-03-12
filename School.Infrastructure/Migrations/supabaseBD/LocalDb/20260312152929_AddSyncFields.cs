using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations.LocalDb
{
    /// <inheritdoc />
    public partial class AddSyncFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rol",
                table: "Persona",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Persona",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nombreUsuario",
                table: "Persona",
                newName: "NombreUsuario");

            migrationBuilder.CreateTable(
                name: "SyncLog",
                columns: table => new
                {
                    TableName = table.Column<string>(type: "text", nullable: false),
                    LastSyncDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncLog", x => x.TableName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SyncLog");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Persona",
                newName: "rol");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Persona",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "Persona",
                newName: "nombreUsuario");
        }
    }
}

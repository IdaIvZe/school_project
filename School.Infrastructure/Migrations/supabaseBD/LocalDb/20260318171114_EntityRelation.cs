using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrastructure.Migrations.LocalDb
{
    /// <inheritdoc />
    public partial class EntityRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Persona");

            migrationBuilder.CreateTable(
                name: "PersonaRoles",
                columns: table => new
                {
                    PersonasId = table.Column<int>(type: "integer", nullable: false),
                    RolesIdRol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRoles", x => new { x.PersonasId, x.RolesIdRol });
                    table.ForeignKey(
                        name: "FK_PersonaRoles_Persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaRoles_Roles_RolesIdRol",
                        column: x => x.RolesIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRoles_RolesIdRol",
                table: "PersonaRoles",
                column: "RolesIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaRoles");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Persona",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

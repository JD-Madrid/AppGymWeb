using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGymWeb.Migrations
{
    /// <inheritdoc />
    public partial class Nuevamigracionconcreaciondecontroladoryvistasparacrearplanesyactividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nnombre",
                table: "Planes",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Planes",
                newName: "Nnombre");
        }
    }
}

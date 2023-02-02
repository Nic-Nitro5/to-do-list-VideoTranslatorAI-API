using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolistapi.Migrations
{
    /// <inheritdoc />
    public partial class Translationcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "translated",
                table: "todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "translated",
                table: "todos");
        }
    }
}

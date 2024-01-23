using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _27_11_23_asp.Migrations
{
    /// <inheritdoc />
    public partial class ispro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPro",
                table: "Contact",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPro",
                table: "Contact");
        }
    }
}

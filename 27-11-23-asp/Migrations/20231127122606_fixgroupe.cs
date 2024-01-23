using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _27_11_23_asp.Migrations
{
    /// <inheritdoc />
    public partial class fixgroupe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.CreateIndex(
                name: "IX_Contact_GroupeId",
                table: "Contact",
                column: "GroupeId");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Groupe_GroupeId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_GroupeId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Contact");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _27_11_23_asp.Migrations
{
    /// <inheritdoc />
    public partial class ContactGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ContactGroup",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroup", x => new { x.ContactId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_ContactGroup_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactGroup_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroup_GroupeId",
                table: "ContactGroup",
                column: "GroupeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactGroup");

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_GroupeId",
                table: "Contact",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Groupe_GroupeId",
                table: "Contact",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id");
        }
    }
}

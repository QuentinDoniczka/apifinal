using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _27_11_23_asp.Migrations
{
    /// <inheritdoc />
    public partial class changeGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Contact",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Groupe_GroupeId",
                table: "Contact",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Groupe_GroupeId",
                table: "Contact",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

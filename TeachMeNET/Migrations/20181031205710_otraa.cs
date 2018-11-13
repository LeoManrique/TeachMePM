using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachMeNET.Migrations
{
    public partial class otraa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "ErrorMessage");

            migrationBuilder.AddColumn<int>(
                name: "InputId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InputModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InputId",
                table: "Users",
                column: "InputId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_InputModel_InputId",
                table: "Users",
                column: "InputId",
                principalTable: "InputModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_InputModel_InputId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "InputModel");

            migrationBuilder.DropIndex(
                name: "IX_Users_InputId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InputId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);
        }
    }
}

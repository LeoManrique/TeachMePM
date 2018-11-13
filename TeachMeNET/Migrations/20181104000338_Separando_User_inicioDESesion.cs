using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachMeNET.Migrations
{
    public partial class Separando_User_inicioDESesion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "InicioSesionId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InicioSesiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InicioSesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InicioSesiones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InicioSesiones_UserId",
                table: "InicioSesiones",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InicioSesiones");

            migrationBuilder.DropColumn(
                name: "InicioSesionId",
                table: "Users");

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
    }
}

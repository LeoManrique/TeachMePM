using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachMeNET.Migrations
{
    public partial class Teachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Degree = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ToHouse = table.Column<int>(nullable: false),
                    MyHouse = table.Column<int>(nullable: false),
                    PublicSpace = table.Column<int>(nullable: false),
                    Online = table.Column<int>(nullable: false),
                    LinkedIn = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Topic1 = table.Column<string>(nullable: true),
                    Price1 = table.Column<int>(nullable: false),
                    Topic2 = table.Column<string>(nullable: true),
                    Price2 = table.Column<int>(nullable: false),
                    Topic3 = table.Column<string>(nullable: true),
                    Price3 = table.Column<int>(nullable: false),
                    Topic4 = table.Column<string>(nullable: true),
                    Price4 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Users",
                nullable: true);
        }
    }
}

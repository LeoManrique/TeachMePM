using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachMeNET.Migrations
{
    public partial class TeachersBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ToHouse",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "PublicSpace",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Online",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "MyHouse",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToHouse",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "PublicSpace",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Online",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "MyHouse",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}

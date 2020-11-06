using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class UpdateAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Starus",
                table: "Action");

            migrationBuilder.AddColumn<string>(
                name: "StatusYear",
                table: "Action",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusYear",
                table: "Action");

            migrationBuilder.AddColumn<string>(
                name: "Starus",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

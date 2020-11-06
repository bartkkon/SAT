using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class AddActionIDOriginal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionIDOriginal",
                table: "PNCSpecial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionIDOriginal",
                table: "PNCList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionIDOriginal",
                table: "CalculationMass",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionIDOriginal",
                table: "Action",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionIDOriginal",
                table: "PNCSpecial");

            migrationBuilder.DropColumn(
                name: "ActionIDOriginal",
                table: "PNCList");

            migrationBuilder.DropColumn(
                name: "ActionIDOriginal",
                table: "CalculationMass");

            migrationBuilder.DropColumn(
                name: "ActionIDOriginal",
                table: "Action");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class Add_Table_Frozen_AddYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Frozen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Frozen");
        }
    }
}

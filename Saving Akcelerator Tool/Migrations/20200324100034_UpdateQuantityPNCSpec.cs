using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class UpdateQuantityPNCSpec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Old_Quant_ANC",
                table: "PNCSpecial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "New_Quant_ANC",
                table: "PNCSpecial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Old_Quant_ANC",
                table: "PNCSpecial",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "New_Quant_ANC",
                table: "PNCSpecial",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class add_PNC3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PNCRevision",
                table: "PNCRevision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PNCMonthly",
                table: "PNCMonthly");

            migrationBuilder.RenameTable(
                name: "PNCRevision",
                newName: "PNCRevision2");

            migrationBuilder.RenameTable(
                name: "PNCMonthly",
                newName: "PNCMonthly2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PNCRevision2",
                table: "PNCRevision2",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PNCMonthly2",
                table: "PNCMonthly2",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PNCRevision2",
                table: "PNCRevision2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PNCMonthly2",
                table: "PNCMonthly2");

            migrationBuilder.RenameTable(
                name: "PNCRevision2",
                newName: "PNCRevision");

            migrationBuilder.RenameTable(
                name: "PNCMonthly2",
                newName: "PNCMonthly");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PNCRevision",
                table: "PNCRevision",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PNCMonthly",
                table: "PNCMonthly",
                column: "ID");
        }
    }
}

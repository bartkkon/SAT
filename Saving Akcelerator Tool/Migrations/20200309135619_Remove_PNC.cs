using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class Remove_PNC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PNCMonthly");

            migrationBuilder.DropTable(
                name: "PNCRevision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PNCMonthly",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    PNC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNCMonthly", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PNCRevision",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    PNC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNCRevision", x => x.ID);
                });
        }
    }
}

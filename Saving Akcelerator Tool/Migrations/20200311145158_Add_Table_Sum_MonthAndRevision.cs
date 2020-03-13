using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class Add_Table_Sum_MonthAndRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SumQuantity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(nullable: true),
                    Installation = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumQuantity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SumRevisionQuantity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(nullable: true),
                    Installation = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Revision = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumRevisionQuantity", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SumQuantity");

            migrationBuilder.DropTable(
                name: "SumRevisionQuantity");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class Add_Table_Frozen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frozen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BU = table.Column<int>(nullable: false),
                    EA1 = table.Column<int>(nullable: false),
                    EA2 = table.Column<int>(nullable: false),
                    EA3 = table.Column<int>(nullable: false),
                    January = table.Column<int>(nullable: false),
                    February = table.Column<int>(nullable: false),
                    March = table.Column<int>(nullable: false),
                    April = table.Column<int>(nullable: false),
                    May = table.Column<int>(nullable: false),
                    June = table.Column<int>(nullable: false),
                    July = table.Column<int>(nullable: false),
                    August = table.Column<int>(nullable: false),
                    September = table.Column<int>(nullable: false),
                    October = table.Column<int>(nullable: false),
                    November = table.Column<int>(nullable: false),
                    December = table.Column<int>(nullable: false),
                    ElectronicApprove = table.Column<int>(nullable: false),
                    MechanicApprove = table.Column<int>(nullable: false),
                    NVRApprove = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frozen", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frozen");
        }
    }
}

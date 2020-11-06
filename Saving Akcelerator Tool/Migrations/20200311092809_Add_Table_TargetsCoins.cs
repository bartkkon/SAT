using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class Add_Table_TargetsCoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Targets_Coins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    ECCC = table.Column<double>(nullable: false),
                    Euro = table.Column<double>(nullable: false),
                    USD = table.Column<double>(nullable: false),
                    SEK = table.Column<double>(nullable: false),
                    DM_BU = table.Column<double>(nullable: false),
                    DM_EA1 = table.Column<double>(nullable: false),
                    DM_EA2 = table.Column<double>(nullable: false),
                    DM_EA3 = table.Column<double>(nullable: false),
                    DM_EA4 = table.Column<double>(nullable: false),
                    PC_BU = table.Column<double>(nullable: false),
                    PC_EA1 = table.Column<double>(nullable: false),
                    PC_EA2 = table.Column<double>(nullable: false),
                    PC_EA3 = table.Column<double>(nullable: false),
                    PC_EA4 = table.Column<double>(nullable: false),
                    Electronic_BU = table.Column<double>(nullable: false),
                    Electronic_EA1 = table.Column<double>(nullable: false),
                    Electronic_EA2 = table.Column<double>(nullable: false),
                    Electronic_EA3 = table.Column<double>(nullable: false),
                    Electronic_EA4 = table.Column<double>(nullable: false),
                    Mechanic_BU = table.Column<double>(nullable: false),
                    Mechanic_EA1 = table.Column<double>(nullable: false),
                    Mechanic_EA2 = table.Column<double>(nullable: false),
                    Mechanic_EA3 = table.Column<double>(nullable: false),
                    Mechanic_EA4 = table.Column<double>(nullable: false),
                    NVR_BU = table.Column<double>(nullable: false),
                    NVR_EA1 = table.Column<double>(nullable: false),
                    NVR_EA2 = table.Column<double>(nullable: false),
                    NVR_EA3 = table.Column<double>(nullable: false),
                    NVR_EA4 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets_Coins", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Targets_Coins");
        }
    }
}

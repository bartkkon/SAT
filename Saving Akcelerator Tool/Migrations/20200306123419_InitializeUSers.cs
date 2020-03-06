using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class InitializeUSers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    ActionTab = table.Column<bool>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    ActionEle = table.Column<bool>(nullable: false),
                    ActionMech = table.Column<bool>(nullable: false),
                    ActionNVR = table.Column<bool>(nullable: false),
                    SummaryTab = table.Column<bool>(nullable: false),
                    STKTab = table.Column<bool>(nullable: false),
                    QuantityTab = table.Column<bool>(nullable: false),
                    AdminTab = table.Column<bool>(nullable: false),
                    ElectronicApprove = table.Column<bool>(nullable: false),
                    MechanicApprove = table.Column<bool>(nullable: false),
                    NVRApprove = table.Column<bool>(nullable: false),
                    PCApprove = table.Column<bool>(nullable: false),
                    StatisticTab = table.Column<bool>(nullable: false),
                    PlatformTab = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

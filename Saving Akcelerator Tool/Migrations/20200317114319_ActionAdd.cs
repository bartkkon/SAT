using Microsoft.EntityFrameworkCore.Migrations;

namespace Saving_Accelerator_Tool.Migrations
{
    public partial class ActionAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StartYear = table.Column<int>(nullable: false),
                    Starus = table.Column<string>(nullable: true),
                    MonthStart = table.Column<string>(nullable: true),
                    Factory = table.Column<string>(nullable: true),
                    Leader = table.Column<string>(nullable: true),
                    Devision = table.Column<string>(nullable: true),
                    Platform_DMD = table.Column<bool>(nullable: false),
                    Platform_D45 = table.Column<bool>(nullable: false),
                    Installation_FI = table.Column<bool>(nullable: false),
                    Installation_FS = table.Column<bool>(nullable: false),
                    Installation_BI = table.Column<bool>(nullable: false),
                    Installation_FSBU = table.Column<bool>(nullable: false),
                    ANC = table.Column<bool>(nullable: false),
                    ANCSpec = table.Column<bool>(nullable: false),
                    PNC = table.Column<bool>(nullable: false),
                    PNCSpec = table.Column<bool>(nullable: false),
                    ECCC = table.Column<bool>(nullable: false),
                    ECCC_Sec = table.Column<double>(nullable: false),
                    ECCC_PNCSpec = table.Column<bool>(nullable: false),
                    PercentQauntity = table.Column<double>(nullable: false),
                    ANC_Calc = table.Column<bool>(nullable: false),
                    Group_Calc = table.Column<bool>(nullable: false),
                    PNCSpec_Estimation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ANCChange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Old_ANC = table.Column<string>(nullable: true),
                    Old_Quant_ANC = table.Column<int>(nullable: false),
                    OLD_IDCO = table.Column<string>(nullable: true),
                    New_ANC = table.Column<string>(nullable: true),
                    New_Quant_ANC = table.Column<int>(nullable: false),
                    New_IDCO = table.Column<string>(nullable: true),
                    Old_STK = table.Column<double>(nullable: false),
                    New_STK = table.Column<double>(nullable: false),
                    Delta = table.Column<double>(nullable: false),
                    Estimation = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    Calculation = table.Column<double>(nullable: false),
                    Next_ANC_1 = table.Column<string>(nullable: true),
                    Next_ANC_2 = table.Column<string>(nullable: true),
                    ANC_Calculation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANCChange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BU",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BU_Carry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BU_Carry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalculationMass",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    DMD_FI = table.Column<bool>(nullable: false),
                    DMD_FS = table.Column<bool>(nullable: false),
                    DMD_BI = table.Column<bool>(nullable: false),
                    DMD_FSBU = table.Column<bool>(nullable: false),
                    D45_FI = table.Column<bool>(nullable: false),
                    D45_FS = table.Column<bool>(nullable: false),
                    D45_BI = table.Column<bool>(nullable: false),
                    D45_FSBU = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationMass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA1",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA1_Carry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA1_Carry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA2",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA2_Carry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA2_Carry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA3",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA3_Carry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA3_Carry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA4",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA4", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EA4_Carry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    Component = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Saving = table.Column<double>(nullable: false),
                    ECCC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA4_Carry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PNCList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    List = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNCList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PNCSpecial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionID = table.Column<int>(nullable: false),
                    PNC = table.Column<string>(nullable: true),
                    ECCC = table.Column<double>(nullable: false),
                    Old_ANC = table.Column<string>(nullable: true),
                    Old_Quant_ANC = table.Column<int>(nullable: false),
                    Old_IDCO = table.Column<string>(nullable: true),
                    New_ANC = table.Column<string>(nullable: true),
                    New_Quant_ANC = table.Column<int>(nullable: false),
                    New_IDCO = table.Column<string>(nullable: true),
                    Old_STK = table.Column<double>(nullable: false),
                    New_STK = table.Column<double>(nullable: false),
                    Delta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNCSpecial", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "ANCChange");

            migrationBuilder.DropTable(
                name: "BU");

            migrationBuilder.DropTable(
                name: "BU_Carry");

            migrationBuilder.DropTable(
                name: "CalculationMass");

            migrationBuilder.DropTable(
                name: "EA1");

            migrationBuilder.DropTable(
                name: "EA1_Carry");

            migrationBuilder.DropTable(
                name: "EA2");

            migrationBuilder.DropTable(
                name: "EA2_Carry");

            migrationBuilder.DropTable(
                name: "EA3");

            migrationBuilder.DropTable(
                name: "EA3_Carry");

            migrationBuilder.DropTable(
                name: "EA4");

            migrationBuilder.DropTable(
                name: "EA4_Carry");

            migrationBuilder.DropTable(
                name: "PNCList");

            migrationBuilder.DropTable(
                name: "PNCSpecial");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseManagementSystem.Server.Migrations
{
    public partial class secondcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group_Codes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscRel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PymntGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayDuMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymntsNum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CredLimit = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    VolumDscnt = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    LatePyChrg = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ObligLimit = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ListNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfPmnts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenRcpt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DunningCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BslineDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TolDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATFirst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrdMthd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CshRelev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Terms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Group_Codes");

            migrationBuilder.DropTable(
                name: "Payment_Terms");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseManagementSystem.Server.Migrations
{
    public partial class thirdcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Upload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Card_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Upload");
        }
    }
}

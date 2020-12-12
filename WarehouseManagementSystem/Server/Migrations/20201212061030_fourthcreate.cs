using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseManagementSystem.Server.Migrations
{
    public partial class fourthcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pending_BPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Card_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PJP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salesman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salesman_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outlet_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outlet_Type_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outlet_Sub_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outlet_Sub_Type_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Type_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terms_of_Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terms_of_Payment_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postal_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAT_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivering_Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivering_Site_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lead_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAG_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSR_Level_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSR_Province_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSR_City_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSR_Barangay_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deactivation_date = table.Column<DateTime>(type: "date", nullable: true),
                    Changed_date = table.Column<DateTime>(type: "date", nullable: true),
                    Payment_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner_ID_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outlet_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Search_Term1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Search_Term2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tax1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "date", nullable: true),
                    Perfect_Store_Audit_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eRTM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requestor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pending_BPs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pending_BPs");
        }
    }
}

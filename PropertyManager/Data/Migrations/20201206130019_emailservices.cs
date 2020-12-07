using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class emailservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutineMaintenceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MaintenanceType = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    CompanyUsed = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: true),
                    RequestSentDate = table.Column<DateTime>(nullable: false),
                    ResponseTime = table.Column<DateTime>(nullable: true),
                    ResponseStatus = table.Column<string>(nullable: true),
                    ResponseMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineMaintenceRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineMaintenceRequests");
        }
    }
}

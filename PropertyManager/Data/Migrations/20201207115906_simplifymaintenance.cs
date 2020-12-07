using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class simplifymaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineMaintenceRequests");

            migrationBuilder.DropTable(
                name: "TenantMaintenanceRequests");

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SubmitterEmail = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    PropertyOwnerId = table.Column<string>(nullable: true),
                    MaintenanceType = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    CompanyUsed = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: true),
                    RequestSentDate = table.Column<DateTime>(nullable: false),
                    ResponseTime = table.Column<DateTime>(nullable: true),
                    ResponseStatus = table.Column<string>(nullable: true),
                    ResponseMessage = table.Column<string>(nullable: true),
                    ResponseCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.CreateTable(
                name: "RoutineMaintenceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    RequestSentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineMaintenceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRequestedForService = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: true),
                    GeneralProblemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    PropertyOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMaintenanceRequests", x => x.Id);
                });
        }
    }
}

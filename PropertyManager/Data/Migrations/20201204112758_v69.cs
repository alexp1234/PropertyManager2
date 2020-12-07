using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class v69 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantMaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmittedBy = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    PropertyOwnerId = table.Column<string>(nullable: true),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    DateRequestedForService = table.Column<DateTime>(nullable: true),
                    GeneralProblemType = table.Column<string>(nullable: true),
                    SpecificProblem = table.Column<string>(nullable: true),
                    ExpenseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMaintenanceRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantMaintenanceRequests");
        }
    }
}

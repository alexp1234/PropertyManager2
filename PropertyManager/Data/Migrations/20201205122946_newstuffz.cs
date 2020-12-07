using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class newstuffz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Properties_InvestmentPropertyId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_InvestmentPropertyId",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "InvestmentPropertyId",
                table: "ServiceProviders");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "TenantMaintenanceRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TenantMaintenanceRequests");

            migrationBuilder.AddColumn<int>(
                name: "InvestmentPropertyId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_InvestmentPropertyId",
                table: "ServiceProviders",
                column: "InvestmentPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Properties_InvestmentPropertyId",
                table: "ServiceProviders",
                column: "InvestmentPropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

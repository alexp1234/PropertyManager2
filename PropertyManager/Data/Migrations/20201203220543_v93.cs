using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class v93 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Properties_PropertyId",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_PropertyId",
                table: "ServiceProviders");

            migrationBuilder.AddColumn<int>(
                name: "InvestmentPropertyId",
                table: "ServiceProviders",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_PropertyId",
                table: "ServiceProviders",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Properties_PropertyId",
                table: "ServiceProviders",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

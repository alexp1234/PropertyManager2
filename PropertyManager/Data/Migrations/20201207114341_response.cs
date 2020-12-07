using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyManager.Data.Migrations
{
    public partial class response : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "RoutineMaintenceRequests",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponseCode",
                table: "RoutineMaintenceRequests",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "RoutineMaintenceRequests");

            migrationBuilder.DropColumn(
                name: "ResponseCode",
                table: "RoutineMaintenceRequests");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bikeShopApi.Migrations
{
    public partial class AddLastLoginAndFailedLoginsToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLogins",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedLogins",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Customers");
        }
    }
}

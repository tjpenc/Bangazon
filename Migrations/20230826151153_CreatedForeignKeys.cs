using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class CreatedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 26, 11, 11, 52, 600, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 26, 11, 11, 52, 600, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.CreateIndex(
                name: "IX_Products_PaymentType",
                table: "Products",
                column: "PaymentType");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_PaymentType",
                table: "Products",
                column: "PaymentType",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_PaymentType",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PaymentType",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 22, 21, 39, 10, 225, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 22, 21, 39, 10, 225, DateTimeKind.Local).AddTicks(9958));
        }
    }
}

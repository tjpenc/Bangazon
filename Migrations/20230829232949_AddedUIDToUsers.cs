using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class AddedUIDToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 192, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 19, 29, 49, 193, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "123",
                column: "UID",
                value: "uid1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "UID",
                value: "uid2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "UID",
                value: "uid3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                column: "UID",
                value: "uid4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "TimeSubmitted",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8692));
        }
    }
}

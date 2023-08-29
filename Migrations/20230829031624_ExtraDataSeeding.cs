using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class ExtraDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Catz");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Sport" },
                    { 3, "Hiking" },
                    { 4, "Dogz" }
                });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Visa");

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 2, "Mastercard" },
                    { 3, "Barter System" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "Email", "Name" },
                values: new object[] { "amogus@email.com", "Amogus" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsSeller", "Name" },
                values: new object[,]
                {
                    { "2", "hammy@email.com", true, "Hammy" },
                    { "3", "sandra@email.com", true, "Sandra" },
                    { "4", "crystal@email.com", false, "Crystal" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "PaymentTypeId", "TimeSubmitted" },
                values: new object[] { "1", 3, new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8419) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsOpen", "PaymentTypeId", "TimeSubmitted" },
                values: new object[,]
                {
                    { 3, "2", true, 2, new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8493) },
                    { 4, "2", false, 2, new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8498) },
                    { 5, "4", false, 2, new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8502) },
                    { 6, "4", false, 2, new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8507) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity", "SellerId", "TimeCreated" },
                values: new object[,]
                {
                    { 2, 4, "A new cat", "Cat", 13, 1, "123", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8666) },
                    { 3, 3, "A new tent", "Tent", 200, 5, "2", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8672) },
                    { 4, 3, "New boots", "Hiking Boots", 150, 2, "2", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8678) },
                    { 5, 3, "A new lantern", "Lantern", 40, 20, "3", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8683) },
                    { 6, 2, "A new baseball", "Baseball", 15, 1, "3", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8688) },
                    { 7, 2, "A new football", "Football", 10, 20, "3", new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8692) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Animal");

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "PaymentTypeId", "TimeSubmitted" },
                values: new object[] { "123", 1, new DateTime(2023, 8, 26, 11, 34, 14, 690, DateTimeKind.Local).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Card");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 26, 11, 34, 14, 690, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "Email", "Name" },
                values: new object[] { "j@email.com", "John" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}

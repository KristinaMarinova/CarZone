using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCarsProject.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Mazda");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Toyota" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BrandId", "CreatedTime" },
                values: new object[] { 12, new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9909) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Toyota");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Mitsubishi" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 560, DateTimeKind.Utc).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2767));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarPic", "ColorId", "CreatedTime", "FuelId", "Horsepower", "IsAvailable", "Km", "LikesCount", "Model", "Price", "TransmissionId", "UserId", "ViewCount", "Year" },
                values: new object[] { 17, 11, "https://g1-bg.cars.bg/2020-09-11_1/5f5b210107c8b8427b4ee022o.jpg", 10, new DateTime(2021, 1, 11, 9, 8, 27, 561, DateTimeKind.Utc).AddTicks(2744), 4, 218, true, 4000, 0, "Camry", 67990.0, 1, 2, 0, 2020 });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCarsProject.Migrations
{
    public partial class hashedPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 771, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 12, 8, 5, 2, 772, DateTimeKind.Utc).AddTicks(3643));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

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
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 11, 9, 12, 10, 809, DateTimeKind.Utc).AddTicks(9931));
        }
    }
}

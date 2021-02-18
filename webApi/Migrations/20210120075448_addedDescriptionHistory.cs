using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebCarsProject.Migrations
{
    public partial class addedDescriptionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    DescriptionDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 157, DateTimeKind.Utc).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedTime",
                value: new DateTime(2021, 1, 20, 7, 54, 48, 158, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_CarId",
                table: "Descriptions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_UserId",
                table: "Descriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

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
    }
}

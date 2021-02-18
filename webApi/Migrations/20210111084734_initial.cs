using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebCarsProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestSavers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Verb = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Protocol = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSavers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserTypeID = table.Column<int>(nullable: false),
                    PicPath = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarPic = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    Horsepower = table.Column<int>(nullable: false),
                    FuelId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Km = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    LikesCount = table.Column<int>(nullable: false),
                    TransmissionId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Audi" },
                    { 3, "Mercedes" },
                    { 4, "Honda" },
                    { 5, "Peugeot" },
                    { 6, "Opel" },
                    { 7, "Skoda" },
                    { 8, "Ford" },
                    { 9, "Mitsubishi" },
                    { 10, "Mitsubishi" },
                    { 11, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Black" },
                    { 9, "Purple" },
                    { 8, "Brown" },
                    { 7, "Pink" },
                    { 6, "Yellow" },
                    { 4, "Green " },
                    { 3, "Blue" },
                    { 2, "White" },
                    { 1, "Red" },
                    { 5, "Grey" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "LPG" },
                    { 2, "Petrol" },
                    { 3, "Diesel" },
                    { 4, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automatic" },
                    { 2, "Manual" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "TypeOfUser" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastLogin", "LastName", "Password", "Phone", "PicPath", "UserName", "UserTypeID" },
                values: new object[,]
                {
                    { 1, "ivan@abv.bg", "Ivan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivanov", "123456", "0877585858", "https://st2.depositphotos.com/2498595/6618/v/950/depositphotos_66187233-stock-illustration-profile-outline-symbol-dark-on.jpg", "ivan777", 1 },
                    { 2, "pesho@gmai.com", "Peho", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petrov", "123456", "0877587777", "https://www.pavilionweb.com/wp-content/uploads/2017/03/man-300x300.png", "pesho123", 2 },
                    { 3, "gosho321@gmai.com", "Gosho", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgiev", "123456", "0877587777", "https://img.icons8.com/bubbles/2x/user-male.png", "gosho321", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarPic", "ColorId", "CreatedTime", "FuelId", "Horsepower", "IsAvailable", "Km", "LikesCount", "Model", "Price", "TransmissionId", "UserId", "ViewCount", "Year" },
                values: new object[,]
                {
                    { 1, 1, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/10best-cars-group-cropped-1542126037.jpg", 1, new DateTime(2021, 1, 11, 8, 47, 34, 345, DateTimeKind.Utc).AddTicks(8079), 1, 100, true, 70000, 0, "M235i", 99000.0, 1, 1, 0, 2020 },
                    { 13, 4, "https://g1-bg.cars.bg/2019-08-02_2/31305837o.jpg", 5, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4470), 2, 161, true, 40181, 0, "Civic ", 26750.0, 1, 3, 0, 2017 },
                    { 12, 4, "https://g1-bg.cars.bg/2020-06-06_2/5edb8a8f752df425d624b483o.jpg", 5, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4449), 3, 150, true, 167000, 0, "Accord", 15800.0, 2, 3, 0, 2010 },
                    { 11, 3, "https://g1-bg.cars.bg/2020-11-18_1/5fb47bb365020349af41da42o.jpg", 6, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4429), 2, 510, true, 25000, 0, "GT", 174999.0, 1, 3, 0, 2016 },
                    { 6, 3, "https://g1-bg.cars.bg/2020-11-22_2/5fba75c4d87c677584246302o.jpg", 5, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4216), 3, 170, true, 235000, 0, "C 220", 9000.0, 2, 3, 0, 2007 },
                    { 18, 1, "https://g1-bg.cars.bg/2020-11-13_2/5fae87399b9c727e493ad622b.jpg", 3, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4571), 1, 140, true, 180000, 0, "530", 21300.0, 2, 2, 0, 2011 },
                    { 17, 11, "https://g1-bg.cars.bg/2020-09-11_1/5f5b210107c8b8427b4ee022o.jpg", 10, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4550), 4, 218, true, 4000, 0, "Camry", 67990.0, 1, 2, 0, 2020 },
                    { 16, 5, "https://g1-bg.cars.bg/2020-10-31_1/5f9cd80b8f564d2c9926e5e2o.jpg", 1, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4529), 2, 225, true, 62000, 0, "508", 66000.0, 1, 2, 0, 2019 },
                    { 10, 3, "https://g1-bg.cars.bg/2020-08-02_2/5f27262e9a1ae76752044183o.jpg", 2, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4406), 2, 500, true, 155000, 0, "C 63", 59900.0, 1, 2, 0, 2010 },
                    { 9, 3, "https://g1-bg.cars.bg/2020-05-24_2/5eca6436267dcc48fc0eedb2o.jpg", 5, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4279), 2, 333, true, 84000, 0, "E 400", 84900.0, 1, 2, 0, 2017 },
                    { 8, 3, "https://g1-bg.cars.bg/2020-06-23_2/5ef1c5866d1c2d269e2cbc14o.jpg", 1, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4258), 3, 204, true, 26000, 0, "GLC 250", 95000.0, 1, 2, 0, 2017 },
                    { 7, 3, "https://g1-bg.cars.bg/2017-11-28_1/17824566o.jpg", 10, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4237), 3, 170, true, 188000, 0, "C 220", 27900.0, 1, 2, 0, 2014 },
                    { 5, 1, "https://g1-bg.cars.bg/2020-07-06_2/5f0352cd072750288a141af2b.jpg", 3, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4190), 1, 160, true, 76000, 0, "320", 25300.0, 1, 2, 0, 2015 },
                    { 4, 1, "https://g1-bg.cars.bg/2020-11-09_2/5fa95efcdf6eec09ae410d12b.jpg", 2, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4168), 3, 150, true, 286000, 0, "E60", 16700.0, 1, 2, 0, 2009 },
                    { 3, 5, "https://g1-bg.cars.bg/2020-08-24_2/5f43bca61b09d640386585d2b.jpg", 2, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4142), 3, 101, true, 91000, 0, "3008", 39999.0, 2, 2, 0, 2017 },
                    { 2, 1, "https://g1-bg.cars.bg/2020-07-14_2/5f0ddd0737b7786f0443bd62o.jpg", 2, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4014), 3, 101, true, 178000, 0, "320", 8000.0, 2, 2, 0, 2006 },
                    { 14, 4, "https://g1-bg.cars.bg/2020-04-07_2/5e8c8f30794ff050e3105964o.jpg", 5, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4489), 2, 182, true, 23000, 0, "Civic ", 39900.0, 1, 3, 0, 2018 },
                    { 15, 4, "https://g1-bg.cars.bg/2020-10-16_1/5f895bf06cb0a84db67d7fb2o.jpg", 1, new DateTime(2021, 1, 11, 8, 47, 34, 346, DateTimeKind.Utc).AddTicks(4509), 3, 160, true, 75600, 0, "CR-v", 46990.0, 1, 3, 0, 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId",
                table: "Cars",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CarId",
                table: "Comments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CarId",
                table: "Likes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "RequestSavers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

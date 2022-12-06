using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniProjectWeek49.Migrations
{
    /// <inheritdoc />
    public partial class seedingMobilesAndLaptopstest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Discriminator", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "iPhone", "Mobile", "8", 970 },
                    { 2, "iPhone", "Mobile", "11", 990 },
                    { 3, "iphone", "Mobile", "X", 1245 },
                    { 4, "Motorola", "Mobile", "Razr", 970 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Discriminator", "Model", "Price", "TargetArea" },
                values: new object[,]
                {
                    { 5, "HP", "Laptop", "Elitebook", 1423, "Home" },
                    { 6, "HP", "Laptop", "Elitebook 2", 970, null },
                    { 7, "Asus", "Laptop", "W234", 1200, null },
                    { 8, "Lenova", "Laptop", "Yoga 730", 835, null },
                    { 9, "Lenova", "Laptop", "Yoga 530", 1030, null }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Currency", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "EUR", "Spain", 0.82645000000000002 },
                    { 2, "USD", "USA", 1.0 },
                    { 3, "SEK", "Sweden", 8.3339999999999996 }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "ItemId", "OfficeId", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2018, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 1, new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 2, new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 2, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 2, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 3, new DateTime(2017, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 3, new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 3, new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ItemId",
                table: "Assets",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OfficeId",
                table: "Assets",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}

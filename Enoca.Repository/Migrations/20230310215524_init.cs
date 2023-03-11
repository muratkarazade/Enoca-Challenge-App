using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enoca.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsStatus = table.Column<bool>(type: "bit", nullable: false),
                    OrderStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OrderFinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdererName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "IsStatus", "Name", "OrderFinishTime", "OrderStartTime" },
                values: new object[] { 1, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6196), true, "Company A", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "IsStatus", "Name", "OrderFinishTime", "OrderStartTime" },
                values: new object[] { 2, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6211), true, "Company B", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "IsStatus", "Name", "OrderFinishTime", "OrderStartTime" },
                values: new object[] { 3, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6213), false, "Company C", new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6406), "Product A1", 50m, 10 },
                    { 2, 1, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6410), "Product A2", 75m, 5 },
                    { 3, 2, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6412), "Product B1", 30m, 20 },
                    { 4, 2, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6413), "Product B2", 40m, 15 },
                    { 5, 3, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6414), "Product C1", 90m, 8 },
                    { 6, 3, new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6416), "Product C2", 80m, 12 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "OrdererName", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", 1 },
                    { 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Veli", 3 },
                    { 3, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmet", 5 },
                    { 4, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mehmet", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

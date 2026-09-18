using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Data.MSSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 999.99m, "15-inch laptop, 16GB RAM, 512GB SSD", "Laptop", "/img/anyProduct.png" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 599.99m, "6.1-inch display, 128GB storage", "Smartphone", "/img/anyProduct.png" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 149.99m, "Wireless noise-cancelling headphones", "Headphones", "/img/anyProduct.png" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 249.99m, "27-inch 4K monitor", "Monitor", "/img/anyProduct.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));
        }
    }
}

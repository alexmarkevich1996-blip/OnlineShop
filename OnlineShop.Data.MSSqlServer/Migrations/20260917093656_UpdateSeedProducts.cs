using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.MSSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Desc1", "Trousers" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Desc1", "Jacket" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Desc2", "Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Desc3", "T-Shirt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "15-inch laptop, 16GB RAM, 512GB SSD", "Laptop" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "6.1-inch display, 128GB storage", "Smartphone" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Wireless noise-cancelling headphones", "Headphones" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "27-inch 4K monitor", "Monitor" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderProvider.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Kimmo Doe" },
                    { "2", "William Doe" },
                    { "3", "Sörén Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}

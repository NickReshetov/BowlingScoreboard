using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingScoreboard.DataAccess.Migrations
{
    public partial class AddLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Rolls");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Rolls");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Games");

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("9f16b43b-9dbe-4d87-8a2a-2abed4923b70"), 1 });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("64c30ed4-ab42-4f24-94d7-b45fbadcfb40"), 2 });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("a06e08f7-77be-465a-9346-dbfc82fe2a06"), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("64c30ed4-ab42-4f24-94d7-b45fbadcfb40"));

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("9f16b43b-9dbe-4d87-8a2a-2abed4923b70"));

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("a06e08f7-77be-465a-9346-dbfc82fe2a06"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Rounds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Rounds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Rolls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Rolls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

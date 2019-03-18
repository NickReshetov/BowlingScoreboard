using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingScoreboard.DataAccess.Migrations
{
    public partial class RoundType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("16cad4d6-2a6a-4e67-a240-c826912fc523"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoundTypeId",
                table: "Rounds",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RoundTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("89f991a8-359a-4482-81d1-f3905ac3f4a0"), 1 });

            migrationBuilder.InsertData(
                table: "RoundTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("287ca5d5-d3da-4c2a-a08a-7f34173a5550"), "Strike" },
                    { new Guid("dc5f774e-905d-40fe-8949-e1087106b5a2"), "Spare" },
                    { new Guid("d2d92cc0-9a18-4c31-9025-abaf089ce50b"), "Open" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_RoundTypeId",
                table: "Rounds",
                column: "RoundTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds",
                column: "RoundTypeId",
                principalTable: "RoundTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "RoundTypes");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_RoundTypeId",
                table: "Rounds");

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("89f991a8-359a-4482-81d1-f3905ac3f4a0"));

            migrationBuilder.DropColumn(
                name: "RoundTypeId",
                table: "Rounds");

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("16cad4d6-2a6a-4e67-a240-c826912fc523"), 1 });
        }
    }
}

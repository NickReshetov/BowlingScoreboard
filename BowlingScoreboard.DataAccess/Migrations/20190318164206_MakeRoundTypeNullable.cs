using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingScoreboard.DataAccess.Migrations
{
    public partial class MakeRoundTypeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds");

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("e1840d44-905e-48c3-aff3-e11aebdffe22"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("309bd6f7-0fb7-4d63-8310-23887496e50a"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("58890a4e-b5ff-4841-b469-a807b9c96c63"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("59337048-c1aa-4b94-a80c-0e32671be4fd"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoundTypeId",
                table: "Rounds",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("8f7af428-1ca3-4739-9b82-758fe94223cf"), 1 });

            migrationBuilder.InsertData(
                table: "RoundTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("859a9204-98a1-4a94-bd10-061edadb703e"), "Strike" },
                    { new Guid("88c1344f-f663-4a49-98e9-4d5dc8320b47"), "Spare" },
                    { new Guid("530094e5-8bb5-4d12-bc93-147a37cdbe4f"), "Open" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds",
                column: "RoundTypeId",
                principalTable: "RoundTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds");

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: new Guid("8f7af428-1ca3-4739-9b82-758fe94223cf"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("530094e5-8bb5-4d12-bc93-147a37cdbe4f"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("859a9204-98a1-4a94-bd10-061edadb703e"));

            migrationBuilder.DeleteData(
                table: "RoundTypes",
                keyColumn: "Id",
                keyValue: new Guid("88c1344f-f663-4a49-98e9-4d5dc8320b47"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoundTypeId",
                table: "Rounds",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Number" },
                values: new object[] { new Guid("e1840d44-905e-48c3-aff3-e11aebdffe22"), 1 });

            migrationBuilder.InsertData(
                table: "RoundTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("58890a4e-b5ff-4841-b469-a807b9c96c63"), "Strike" },
                    { new Guid("59337048-c1aa-4b94-a80c-0e32671be4fd"), "Spare" },
                    { new Guid("309bd6f7-0fb7-4d63-8310-23887496e50a"), "Open" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTypes_RoundTypeId",
                table: "Rounds",
                column: "RoundTypeId",
                principalTable: "RoundTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

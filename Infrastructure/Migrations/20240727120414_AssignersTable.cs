using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssignersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventAssigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    SportEventId = table.Column<int>(type: "int", nullable: false),
                    AssignedPeople = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAssigners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAssigners_SportEvents_SportEventId",
                        column: x => x.SportEventId,
                        principalTable: "SportEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15575a0-84e8-495c-966b-68113b26b143", "AQAAAAIAAYagAAAAEDJf20C8vkTIUq7G88/fgp4ORdZP8voQBME1d0+oWGNI4iqeIZUFcteCz3jSjoi+dA==", "0e721ef9-0ddd-4d86-9172-8f6341070da3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee745aa9-b056-4cae-b385-231862ca023b", "AQAAAAIAAYagAAAAEKeDFg721BUnHsPDPLh2Uc3Et9m+ysGXHzd37ztJmpQ01X1UPHEwrVEUebhhlh2qHA==", "3f106a22-ffcc-4cc3-bc3e-7839bb3fb7f5" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "myuser@email.com", new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6583) });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "myuser@email.com", new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "myuser@email.com", new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.CreateIndex(
                name: "IX_EventAssigners_SportEventId",
                table: "EventAssigners",
                column: "SportEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAssigners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cf05497-8192-4932-8b7e-ac149a956a4d", "AQAAAAIAAYagAAAAEOXPVN5BFfxAhgG3Ch2va7V3rm3YhaiJ1uUgOjazAMtGFSOosp3L9QTlZUzOKt5QuQ==", "bc600970-5560-415d-9f6c-475ed22248a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b0325c-60b2-417d-8d56-0955fd210d3e", "AQAAAAIAAYagAAAAELZ5tS0qBKfkrrzcWZx9EZXPs2v3t9ePjuld2fQ+q3dLEABZT0jat4LuwFeHZ8iRAA==", "bfc08c7c-b016-42c6-8f26-03fe6c5a34b3" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 8, 18, 32, 3, 701, DateTimeKind.Local).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 8, 18, 32, 3, 701, DateTimeKind.Local).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "DateWhen" },
                values: new object[] { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 8, 18, 32, 3, 701, DateTimeKind.Local).AddTicks(9994) });
        }
    }
}

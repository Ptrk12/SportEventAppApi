using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedCreatedByCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41cff596-de9f-4bd1-89c8-b678be3e0dfa", "AQAAAAIAAYagAAAAEN1SIBe4j2u0dO26NRvdp7qLx58JetQlfXhNzNSJAlFeQr+AmQSNdf/FMKDczbqJAg==", "318a2952-f4eb-4ed8-b4b2-53a4c0c035a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a0af09d-2fea-4515-82f8-1b996e51f645", "AQAAAAIAAYagAAAAEI6ogEbN76hBHej5P6ulXe/etmgrZpRnHSOLcK4aaE45RXZa7kVVT73ayXKk4YWy+g==", "8a495c01-639b-4c7b-8e86-52b028a5da36" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedBy",
                value: "myuser@email.com");

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhen",
                value: new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Objects");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abf5b012-bd9b-4ef1-8ac6-4b294c8e8e95", "AQAAAAIAAYagAAAAEL1uv8Y5f63aHR6ly0fuJd6oWM2W0ZD1sutErXvta+3yYDJAchrKqZZyOEv/RenQ/A==", "49b2ed1c-46a9-4e00-adec-b73e8dc2b066" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "402d0301-4ad9-4dd2-811b-27cb11d895f6", "AQAAAAIAAYagAAAAEFfeAmdZYbf4WV65CHb8FEJhACmrti0MaymiZsi6MtoYEbir+alk809pFqNhahRdzg==", "a8a373cd-2a4a-4168-80cd-858a952cd7ac" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhen",
                value: new DateTime(2024, 10, 13, 13, 55, 12, 421, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2024, 10, 13, 13, 55, 12, 421, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2024, 10, 13, 13, 55, 12, 421, DateTimeKind.Local).AddTicks(4361));
        }
    }
}

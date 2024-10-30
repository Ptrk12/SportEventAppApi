using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userMoney : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SportEvents");

            migrationBuilder.AddColumn<double>(
                name: "PricePerHour",
                table: "Objects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", 0, "752ed554-3b23-4006-9b79-538fe7bd0036", "UserEntity", "myuser@email.com", false, false, null, 100.0, "MYUSER@EMAIL.COM", "MYUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEFcekVra4+D4FR32WZpLeV668owTsR5H0IrOyWU75y2Pj5DM9tL2OLnfQ/7ZfiecKQ==", null, false, "60d031ab-74f3-4818-a8b5-327fdc0fc555", false, "myuser@email.com" },
                    { "d3e7c295-d723-4d8e-8c39-be6107f44020", 0, "4d2dfb12-4072-4c8a-a751-fa50cc6e050b", "UserEntity", "admin@email.com", false, false, null, 100.0, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEHYlg62GivCXECpxTRC50l2PSbBW7ql8jpEUcyQGv9XOdJvYvXa1x8xjCRLa5uI7aQ==", null, false, "ad3bd4de-6ace-4d50-ac73-a31402b7dc85", false, "admin@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 5,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 6,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 8,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 9,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 10,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 11,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 12,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 13,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 14,
                column: "PricePerHour",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 17, 20, 672, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 17, 20, 672, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 17, 20, 672, DateTimeKind.Local).AddTicks(1267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerHour",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SportEvents",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

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
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateWhen", "Price" },
                values: new object[] { new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(170), 20.0m });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateWhen", "Price" },
                values: new object[] { new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(297), 22.0m });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateWhen", "Price" },
                values: new object[] { new DateTime(2024, 10, 22, 13, 52, 12, 911, DateTimeKind.Local).AddTicks(356), 23.0m });
        }
    }
}

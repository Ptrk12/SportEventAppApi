using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userOvverrideTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffdb4d04-09db-4983-82bc-ffab05b153d4", "AQAAAAIAAYagAAAAENScNzm1noQccJrtPofE48gYmbOj6f9t886HQS56JiWQqbCEiVEJWOEuuu8by6ul1g==", "926c3a4f-a1b4-48bd-9480-443fc7a9ae7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d7ba903-2e62-474b-8083-825248ef978e", "AQAAAAIAAYagAAAAEAJPvQVEhcWlGZdd4mmL/zA1X13p9g7XK61m1/rpp5CoSNfE2Z1X58SJD+Kdm8v6ZQ==", "68545413-0051-4615-b6af-42c7e948de7e" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 22, 48, 223, DateTimeKind.Local).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 22, 48, 223, DateTimeKind.Local).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2024, 10, 30, 14, 22, 48, 223, DateTimeKind.Local).AddTicks(5763));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "752ed554-3b23-4006-9b79-538fe7bd0036", "AQAAAAIAAYagAAAAEFcekVra4+D4FR32WZpLeV668owTsR5H0IrOyWU75y2Pj5DM9tL2OLnfQ/7ZfiecKQ==", "60d031ab-74f3-4818-a8b5-327fdc0fc555" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d2dfb12-4072-4c8a-a751-fa50cc6e050b", "AQAAAAIAAYagAAAAEHYlg62GivCXECpxTRC50l2PSbBW7ql8jpEUcyQGv9XOdJvYvXa1x8xjCRLa5uI7aQ==", "ad3bd4de-6ace-4d50-ac73-a31402b7dc85" });

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
    }
}

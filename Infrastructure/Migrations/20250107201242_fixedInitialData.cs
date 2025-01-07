using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "822e520f-db92-4006-8791-872045d9084d", "AQAAAAIAAYagAAAAEAU7KXwknoUh8xTnNiv/zVE9TIAyNTmhuDhn/rC3I9QbPf6YnEF0KzsVeoLsZsw+Wg==", "9bf3ada4-7e18-477b-9bca-9ebc21a2f023" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2778bdd-b430-4f60-9ed7-b6a024c90faa", "AQAAAAIAAYagAAAAEIvheDoGCukXbaoPV0m7O6YHjkPH57cXoMlIhfsg8b4gsQWCf+wq1//dTvgAPjFSSg==", "346e6be8-b0a9-4dc4-a13c-bed62eaf2162" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2027, 1, 7, 21, 12, 42, 268, DateTimeKind.Local).AddTicks(5076), 1 });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2027, 1, 7, 21, 12, 42, 268, DateTimeKind.Local).AddTicks(5247), 1 });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2027, 1, 7, 21, 12, 42, 268, DateTimeKind.Local).AddTicks(5287), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd54ab02-feaa-4db6-a377-738490ced651", "AQAAAAIAAYagAAAAEEW2bsUBbgCS+0f9kW4hamOz2G7Sl7MVHJ6wcTB+MJ022XdjivrQcx0Y62zAZio2yA==", "871d3e5d-9505-4fe4-80fa-548a9c139fd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac826523-c8cf-47ea-9c9d-e9cfb31acd11", "AQAAAAIAAYagAAAAEFGLd+eNjBotE1l3R938H4rjGpX3tD/mmodCQWzUTqCL1g42/ffHkz3lRzJ1atI52g==", "8769b43c-f7d5-4188-99ef-4d3cde425e59" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4061), 60 });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4177), 30 });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateWhen", "Time" },
                values: new object[] { new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4244), 120 });
        }
    }
}

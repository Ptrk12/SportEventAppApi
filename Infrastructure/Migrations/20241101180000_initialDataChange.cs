using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialDataChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "114c9db1-bbf4-4f97-bf71-51605000efc6", "AQAAAAIAAYagAAAAEFG8NDtUY7vwvc/SdB3DD+DC/DqisIpP3i/kflskrpCT/GomgHTSD76oBimFekGlUw==", "b402de0c-46d9-4f4e-ac08-b28489a5919b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac892bfa-aa37-414f-987e-089c4042107b", "AQAAAAIAAYagAAAAEFfC78M2DvGk5jqt7YwhdRhXooCJBT0MMnoGsZivOBfxWLV1SwWZTTTGrRr2gJyw5w==", "2df51cc8-79ae-48e4-a18a-2fab26e44f85" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhen",
                value: new DateTime(2026, 11, 1, 19, 0, 0, 313, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2026, 11, 1, 19, 0, 0, 313, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2026, 11, 1, 19, 0, 0, 313, DateTimeKind.Local).AddTicks(7252));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

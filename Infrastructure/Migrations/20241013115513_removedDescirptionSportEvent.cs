using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removedDescirptionSportEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SportEvents");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SportEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9eaedfc-38fe-4706-8a0c-c8cee39c7140", "AQAAAAIAAYagAAAAEMKUrLwZCM/MuipTcurt3pelfQ52HPO7asCtnuYOOa7f5ib5cHtlpcEGt8cZjy2fEg==", "8f5c1c41-d202-43a2-8e49-f16009e2dff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1022e327-5cf7-493b-9747-2b7bad9ac67e", "AQAAAAIAAYagAAAAEJsH5Eq2gn6erek1DTsAEQ4py9jGK+zXzsWFH9/LH0U78RibYGKmF8W8y2qdVej7sA==", "9d29e828-4c8c-42c7-aaf1-af56f88f4537" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateWhen", "Description" },
                values: new object[] { new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8423), "Desc 1" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateWhen", "Description" },
                values: new object[] { new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8644), "Desc 2" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateWhen", "Description" },
                values: new object[] { new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8665), "Desc 3" });
        }
    }
}

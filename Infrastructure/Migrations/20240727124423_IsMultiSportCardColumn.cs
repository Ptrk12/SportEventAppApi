using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsMultiSportCardColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultiSportCard",
                table: "SportEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79b89943-dd8d-4b8c-963c-31533455f6f5", "AQAAAAIAAYagAAAAEI37W65KDcu1+P/8qrCmte7796UP8aMvHSlfpGsDIHdTNuZObOo/sdREs96SGWVLZA==", "9995c0e3-79c3-4b60-a47f-34e3d1153808" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e7c295-d723-4d8e-8c39-be6107f44020",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff2c1ee3-209f-4227-b517-48b32ef94c09", "AQAAAAIAAYagAAAAEGPaHhxc6wQDvkNytpsvFcYCFiQdtWSXGT8fES8k6thKrSYdV2GSs2zDz6yu5Ryg+Q==", "88edd960-1eb2-47d1-a2cd-d8b2723a0ea7" });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateWhen", "IsMultiSportCard" },
                values: new object[] { new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2154), true });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateWhen", "IsMultiSportCard" },
                values: new object[] { new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2274), true });

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateWhen", "IsMultiSportCard" },
                values: new object[] { new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2305), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMultiSportCard",
                table: "SportEvents");

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
                column: "DateWhen",
                value: new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateWhen",
                value: new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateWhen",
                value: new DateTime(2024, 7, 27, 14, 4, 12, 567, DateTimeKind.Local).AddTicks(6680));
        }
    }
}

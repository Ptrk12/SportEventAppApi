using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportEventAppApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AmountOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    DateWhen = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportEvents_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopObjects_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "942aa41c-1955-4bb0-93ca-f25e26506cc8", null, "administrator", "ADMINISTRATOR" },
                    { "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e", null, "generalUser", "GENERALUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", 0, "51ace4f4-8ad6-4cbc-bf44-5da0326486f5", "myuser@email.com", false, false, null, "MYUSER@EMAIL.COM", "MYUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEMJFzdJajEjdU4mFxJ6ocrC+oGI+HqCIToQ0BJCRpQbXrEvEgKeiTjgHlw4PjtjXjg==", null, false, "14f11149-9d11-4524-bb8d-7bd57fba024d", false, "myuser@email.com" },
                    { "d3e7c295-d723-4d8e-8c39-be6107f44020", 0, "0c8a90a2-26c6-41eb-82c8-694f031562fd", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEKus75IdXI2W24ISq9EFLtAHklbOFeIho2Sw3PV5n5cdrLk0MKXUrMysXw9UAIiUWQ==", null, false, "5c766d4f-2e4b-477a-bef2-71239c821a33", false, "admin@email.com" }
                });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Adress", "City", "Description", "Name", "ObjectType" },
                values: new object[,]
                {
                    { 1, "Tadeusza Ptaszyckiego 6, 31-979 Kraków", "Krakow", "", "Com-Com Zone", "Hall" },
                    { 2, "Wawelska 3, 02-034 Warszawa", "Warszawa", "", "III Ogród Jordanowski", "Sports_field" },
                    { 3, "Nowowiejska 37B, 02-079 Warszawa", "Warszawa", "", "Ośrodek Sportu i Rekreacji Dzielnicy Ochota", "Hall" },
                    { 4, "Siennicka 40B, 04-393 Warszawa", "Warszawa", "", "OSiR Praga-Południe: Hala Sportowa Siennicka", "Hall" },
                    { 5, "Michała Ossowskiego 25, 03-542 Warszawa", "Warszawa", "", "OSiR Targówek Hala Sportowa", "Hall" },
                    { 6, "al. 29 Listopada 58, 31-425 Kraków", "Krakow", "", "Hala Sportowa, Uniwersytet Rolniczy w Krakowie", "Hall" },
                    { 7, "Kamienna 17, 30-001 Kraków", "Krakow", "", "Centrum Sportu i Rekreacji Politechniki Krakowskiej", "Hall" },
                    { 8, "Kazimierza Czapińskiego 5, 30-048 Kraków", "Krakow", "", "Hala sportowa przy IX LO", "Hall" },
                    { 9, "Niebieska 15, 30-685 Kraków", "Krakow", "", "Hala Sportowa Orzeł Piaski Wielkie", "Hall" },
                    { 10, "Aleja Marszałka Ferdynanda Focha 40, 30-119 Kraków", "Krakow", "", "Hala 100-lecia KS Cracovia wraz z Centrum Sportu Niepełnosprawnych", "Hall" },
                    { 11, "ul. Pułtuska 13, 53-116 Wrocław", "Wroclaw", "", "KKT Wrocław Stowarzyszenie Krzycki Klub Tenisowy", "Hall" },
                    { 12, "ul. Paderewskiego 35", "Wroclaw", "", "Hala tenisowa i korty tenisowe AWF", "Hall" },
                    { 13, "ul. Góralska 5", "Wroclaw", "", "Centrum sportowe Hasta La Vista", "Hall" },
                    { 14, "ul. Kozanowska 69", "Wroclaw", "", "Centrum sportu i rekreacji Sportwerk", "Hall" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e", "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612" },
                    { "942aa41c-1955-4bb0-93ca-f25e26506cc8", "d3e7c295-d723-4d8e-8c39-be6107f44020" }
                });

            migrationBuilder.InsertData(
                table: "SportEvents",
                columns: new[] { "Id", "AmountOfPlayers", "CreatedBy", "DateWhen", "Description", "Discipline", "Name", "ObjectId", "Price", "SkillLevel", "Time" },
                values: new object[,]
                {
                    { 1, 12, "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 5, 16, 36, 17, 960, DateTimeKind.Local).AddTicks(8639), "Desc 1", "Football", "", 14, 20.0m, "Amateur", 60 },
                    { 2, 6, "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 5, 16, 36, 17, 960, DateTimeKind.Local).AddTicks(8753), "Desc 2", "Football", "", 4, 22.0m, "Amateur", 30 },
                    { 3, 10, "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", new DateTime(2024, 5, 5, 16, 36, 17, 960, DateTimeKind.Local).AddTicks(8780), "Desc 3", "Football", "", 12, 23.0m, "Amateur", 120 }
                });

            migrationBuilder.InsertData(
                table: "TopObjects",
                columns: new[] { "Id", "ObjectId", "Points" },
                values: new object[,]
                {
                    { 1, 12, 90 },
                    { 2, 13, 21 },
                    { 3, 14, 66 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_ObjectId",
                table: "SportEvents",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TopObjects_ObjectId",
                table: "TopObjects",
                column: "ObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SportEvents");

            migrationBuilder.DropTable(
                name: "TopObjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Objects");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    DateWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMultiSportCard = table.Column<bool>(type: "bit", nullable: false)
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
                    { "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612", 0, "e9eaedfc-38fe-4706-8a0c-c8cee39c7140", "myuser@email.com", false, false, null, "MYUSER@EMAIL.COM", "MYUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEMKUrLwZCM/MuipTcurt3pelfQ52HPO7asCtnuYOOa7f5ib5cHtlpcEGt8cZjy2fEg==", null, false, "8f5c1c41-d202-43a2-8e49-f16009e2dff8", false, "myuser@email.com" },
                    { "d3e7c295-d723-4d8e-8c39-be6107f44020", 0, "1022e327-5cf7-493b-9747-2b7bad9ac67e", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEJsH5Eq2gn6erek1DTsAEQ4py9jGK+zXzsWFH9/LH0U78RibYGKmF8W8y2qdVej7sA==", null, false, "9d29e828-4c8c-42c7-aaf1-af56f88f4537", false, "admin@email.com" }
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
                columns: new[] { "Id", "AmountOfPlayers", "CreatedBy", "DateWhen", "Description", "Discipline", "IsMultiSportCard", "Name", "ObjectId", "Price", "SkillLevel", "Time" },
                values: new object[,]
                {
                    { 1, 12, "myuser@email.com", new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8423), "Desc 1", "Football", true, "", 14, 20.0m, "Amateur", 60 },
                    { 2, 6, "myuser@email.com", new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8644), "Desc 2", "Football", true, "", 4, 22.0m, "Amateur", 30 },
                    { 3, 10, "myuser@email.com", new DateTime(2024, 8, 24, 16, 19, 1, 241, DateTimeKind.Local).AddTicks(8665), "Desc 3", "Football", false, "", 12, 23.0m, "Amateur", 120 }
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
                name: "IX_EventAssigners_SportEventId",
                table: "EventAssigners",
                column: "SportEventId");

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
                name: "EventAssigners");

            migrationBuilder.DropTable(
                name: "TopObjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SportEvents");

            migrationBuilder.DropTable(
                name: "Objects");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportEventAppApi.Config;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SportEventAppDbContext))]
    partial class SportEventAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.EventAssignersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssignedPeople")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("SportEventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportEventId");

                    b.ToTable("EventAssigners");
                });

            modelBuilder.Entity("Infrastructure.Entities.ObjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Objects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Tadeusza Ptaszyckiego 6, 31-979 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Com-Com Zone",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Wawelska 3, 02-034 Warszawa",
                            City = "Warszawa",
                            Description = "",
                            Name = "III Ogród Jordanowski",
                            ObjectType = "Sports_field"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Nowowiejska 37B, 02-079 Warszawa",
                            City = "Warszawa",
                            Description = "",
                            Name = "Ośrodek Sportu i Rekreacji Dzielnicy Ochota",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 4,
                            Adress = "Siennicka 40B, 04-393 Warszawa",
                            City = "Warszawa",
                            Description = "",
                            Name = "OSiR Praga-Południe: Hala Sportowa Siennicka",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 5,
                            Adress = "Michała Ossowskiego 25, 03-542 Warszawa",
                            City = "Warszawa",
                            Description = "",
                            Name = "OSiR Targówek Hala Sportowa",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 6,
                            Adress = "al. 29 Listopada 58, 31-425 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Hala Sportowa, Uniwersytet Rolniczy w Krakowie",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 7,
                            Adress = "Kamienna 17, 30-001 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Centrum Sportu i Rekreacji Politechniki Krakowskiej",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 8,
                            Adress = "Kazimierza Czapińskiego 5, 30-048 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Hala sportowa przy IX LO",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 9,
                            Adress = "Niebieska 15, 30-685 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Hala Sportowa Orzeł Piaski Wielkie",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 10,
                            Adress = "Aleja Marszałka Ferdynanda Focha 40, 30-119 Kraków",
                            City = "Krakow",
                            Description = "",
                            Name = "Hala 100-lecia KS Cracovia wraz z Centrum Sportu Niepełnosprawnych",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 11,
                            Adress = "ul. Pułtuska 13, 53-116 Wrocław",
                            City = "Wroclaw",
                            Description = "",
                            Name = "KKT Wrocław Stowarzyszenie Krzycki Klub Tenisowy",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 12,
                            Adress = "ul. Paderewskiego 35",
                            City = "Wroclaw",
                            Description = "",
                            Name = "Hala tenisowa i korty tenisowe AWF",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 13,
                            Adress = "ul. Góralska 5",
                            City = "Wroclaw",
                            Description = "",
                            Name = "Centrum sportowe Hasta La Vista",
                            ObjectType = "Hall"
                        },
                        new
                        {
                            Id = 14,
                            Adress = "ul. Kozanowska 69",
                            City = "Wroclaw",
                            Description = "",
                            Name = "Centrum sportu i rekreacji Sportwerk",
                            ObjectType = "Hall"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.SportEventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountOfPlayers")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateWhen")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMultiSportCard")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("SportEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountOfPlayers = 12,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2154),
                            Description = "Desc 1",
                            Discipline = "Football",
                            IsMultiSportCard = true,
                            Name = "",
                            ObjectId = 14,
                            Price = 20.0m,
                            SkillLevel = "Amateur",
                            Time = 60
                        },
                        new
                        {
                            Id = 2,
                            AmountOfPlayers = 6,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2274),
                            Description = "Desc 2",
                            Discipline = "Football",
                            IsMultiSportCard = true,
                            Name = "",
                            ObjectId = 4,
                            Price = 22.0m,
                            SkillLevel = "Amateur",
                            Time = 30
                        },
                        new
                        {
                            Id = 3,
                            AmountOfPlayers = 10,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2024, 7, 27, 14, 44, 21, 460, DateTimeKind.Local).AddTicks(2305),
                            Description = "Desc 3",
                            Discipline = "Football",
                            IsMultiSportCard = false,
                            Name = "",
                            ObjectId = 12,
                            Price = 23.0m,
                            SkillLevel = "Amateur",
                            Time = 120
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.TopObjectsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("TopObjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ObjectId = 12,
                            Points = 90
                        },
                        new
                        {
                            Id = 2,
                            ObjectId = 13,
                            Points = 21
                        },
                        new
                        {
                            Id = 3,
                            ObjectId = 14,
                            Points = 66
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e",
                            Name = "generalUser",
                            NormalizedName = "GENERALUSER"
                        },
                        new
                        {
                            Id = "942aa41c-1955-4bb0-93ca-f25e26506cc8",
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "79b89943-dd8d-4b8c-963c-31533455f6f5",
                            Email = "myuser@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MYUSER@EMAIL.COM",
                            NormalizedUserName = "MYUSER@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEI37W65KDcu1+P/8qrCmte7796UP8aMvHSlfpGsDIHdTNuZObOo/sdREs96SGWVLZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9995c0e3-79c3-4b60-a47f-34e3d1153808",
                            TwoFactorEnabled = false,
                            UserName = "myuser@email.com"
                        },
                        new
                        {
                            Id = "d3e7c295-d723-4d8e-8c39-be6107f44020",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff2c1ee3-209f-4227-b517-48b32ef94c09",
                            Email = "admin@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "ADMIN@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGPaHhxc6wQDvkNytpsvFcYCFiQdtWSXGT8fES8k6thKrSYdV2GSs2zDz6yu5Ryg+Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "88edd960-1eb2-47d1-a2cd-d8b2723a0ea7",
                            TwoFactorEnabled = false,
                            UserName = "admin@email.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                            RoleId = "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e"
                        },
                        new
                        {
                            UserId = "d3e7c295-d723-4d8e-8c39-be6107f44020",
                            RoleId = "942aa41c-1955-4bb0-93ca-f25e26506cc8"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Entities.EventAssignersEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.SportEventEntity", "SportEvent")
                        .WithMany()
                        .HasForeignKey("SportEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SportEvent");
                });

            modelBuilder.Entity("Infrastructure.Entities.SportEventEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.ObjectEntity", "Object")
                        .WithMany("SportEvents")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");
                });

            modelBuilder.Entity("Infrastructure.Entities.TopObjectsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.ObjectEntity", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Entities.ObjectEntity", b =>
                {
                    b.Navigation("SportEvents");
                });
#pragma warning restore 612, 618
        }
    }
}

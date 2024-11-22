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

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerHour")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Objects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Tadeusza Ptaszyckiego 6, 31-979 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Com-Com Zone",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Wawelska 3, 02-034 Warszawa",
                            City = "Warszawa",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "III Ogród Jordanowski",
                            ObjectType = "Sports_field",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Nowowiejska 37B, 02-079 Warszawa",
                            City = "Warszawa",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Ośrodek Sportu i Rekreacji Dzielnicy Ochota",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 4,
                            Adress = "Siennicka 40B, 04-393 Warszawa",
                            City = "Warszawa",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "OSiR Praga-Południe: Hala Sportowa Siennicka",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 5,
                            Adress = "Michała Ossowskiego 25, 03-542 Warszawa",
                            City = "Warszawa",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "OSiR Targówek Hala Sportowa",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 6,
                            Adress = "al. 29 Listopada 58, 31-425 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Hala Sportowa, Uniwersytet Rolniczy w Krakowie",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 7,
                            Adress = "Kamienna 17, 30-001 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Centrum Sportu i Rekreacji Politechniki Krakowskiej",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 8,
                            Adress = "Kazimierza Czapińskiego 5, 30-048 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Hala sportowa przy IX LO",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 9,
                            Adress = "Niebieska 15, 30-685 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Hala Sportowa Orzeł Piaski Wielkie",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 10,
                            Adress = "Aleja Marszałka Ferdynanda Focha 40, 30-119 Kraków",
                            City = "Krakow",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Hala 100-lecia KS Cracovia wraz z Centrum Sportu Niepełnosprawnych",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 11,
                            Adress = "ul. Pułtuska 13, 53-116 Wrocław",
                            City = "Wroclaw",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "KKT Wrocław Stowarzyszenie Krzycki Klub Tenisowy",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 12,
                            Adress = "ul. Paderewskiego 35",
                            City = "Wroclaw",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Hala tenisowa i korty tenisowe AWF",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 13,
                            Adress = "ul. Góralska 5",
                            City = "Wroclaw",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Centrum sportowe Hasta La Vista",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
                        },
                        new
                        {
                            Id = 14,
                            Adress = "ul. Kozanowska 69",
                            City = "Wroclaw",
                            CreatedBy = "myuser@email.com",
                            Description = "",
                            Name = "Centrum sportu i rekreacji Sportwerk",
                            ObjectType = "Hall",
                            PricePerHour = 200.0
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
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("DateWhen")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ObjectId");

                    b.ToTable("SportEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountOfPlayers = 12,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4061),
                            Discipline = "Football",
                            IsMultiSportCard = true,
                            Name = "",
                            ObjectId = 14,
                            SkillLevel = "Amateur",
                            Time = 60
                        },
                        new
                        {
                            Id = 2,
                            AmountOfPlayers = 6,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4177),
                            Discipline = "Football",
                            IsMultiSportCard = true,
                            Name = "",
                            ObjectId = 4,
                            SkillLevel = "Amateur",
                            Time = 30
                        },
                        new
                        {
                            Id = 3,
                            AmountOfPlayers = 10,
                            CreatedBy = "myuser@email.com",
                            DateWhen = new DateTime(2026, 11, 22, 10, 48, 46, 44, DateTimeKind.Local).AddTicks(4244),
                            Discipline = "Football",
                            IsMultiSportCard = false,
                            Name = "",
                            ObjectId = 12,
                            SkillLevel = "Amateur",
                            Time = 120
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

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
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("Infrastructure.Entities.UserEntity", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("UserEntity");

                    b.HasData(
                        new
                        {
                            Id = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bd54ab02-feaa-4db6-a377-738490ced651",
                            Email = "myuser@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MYUSER@EMAIL.COM",
                            NormalizedUserName = "MYUSER@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEW2bsUBbgCS+0f9kW4hamOz2G7Sl7MVHJ6wcTB+MJ022XdjivrQcx0Y62zAZio2yA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "871d3e5d-9505-4fe4-80fa-548a9c139fd4",
                            TwoFactorEnabled = false,
                            UserName = "myuser@email.com",
                            Money = 100.0
                        },
                        new
                        {
                            Id = "d3e7c295-d723-4d8e-8c39-be6107f44020",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ac826523-c8cf-47ea-9c9d-e9cfb31acd11",
                            Email = "admin@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "ADMIN@EMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFGLd+eNjBotE1l3R938H4rjGpX3tD/mmodCQWzUTqCL1g42/ffHkz3lRzJ1atI52g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8769b43c-f7d5-4188-99ef-4d3cde425e59",
                            TwoFactorEnabled = false,
                            UserName = "admin@email.com",
                            Money = 100.0
                        });
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

            modelBuilder.Entity("Infrastructure.Entities.ObjectEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .HasPrincipalKey("UserName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Entities.SportEventEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .HasPrincipalKey("UserName")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Infrastructure.Entities.ObjectEntity", "Object")
                        .WithMany("SportEvents")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Object");

                    b.Navigation("User");
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

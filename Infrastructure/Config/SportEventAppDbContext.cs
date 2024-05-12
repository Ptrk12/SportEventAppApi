using Infrastructure.Entities;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace SportEventAppApi.Config
{
    public class SportEventAppDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        public SportEventAppDbContext(DbContextOptions<SportEventAppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<ObjectEntity> Objects { get; set; }
        public DbSet<SportEventEntity> SportEvents { get; set; }
        public DbSet<TopObjectsEntity> TopObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("SqlConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<IdentityRole>();

            modelBuilder.Entity<SportEventEntity>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<ObjectEntity>()
                .HasMany(x => x.SportEvents)
                .WithOne(x => x.Object);

            modelBuilder.Entity<TopObjectsEntity>()
                .HasOne(x => x.Object);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e",
                Name="generalUser",
                NormalizedName = "GENERALUSER"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "942aa41c-1955-4bb0-93ca-f25e26506cc8",
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR"
            });


            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                    UserName = "myuser@email.com",
                    Email = "myuser@email.com",
                    NormalizedUserName = "MYUSER@EMAIL.COM",
                    NormalizedEmail = "MYUSER@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Test123!")
                },
                new IdentityUser
                {
                    Id = "d3e7c295-d723-4d8e-8c39-be6107f44020",
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    NormalizedUserName = "ADMIN@EMAIL.COM",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Test123!")
                }
            ); 


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "ba5a6f54-9bbb-4936-bc6c-56b9f4af9d6e",
                    UserId = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "942aa41c-1955-4bb0-93ca-f25e26506cc8",
                    UserId = "d3e7c295-d723-4d8e-8c39-be6107f44020"
                }
            );

            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 1,
                    Name = "Com-Com Zone",
                    Description = "",
                    Adress = "Tadeusza Ptaszyckiego 6, 31-979 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 2,
                    Name = "III Ogród Jordanowski",
                    Description = "",
                    Adress = "Wawelska 3, 02-034 Warszawa",
                    City = Cities.Warszawa.ToString(),
                    ObjectType = ObjectTypes.Sports_field.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 3,
                    Name = "Ośrodek Sportu i Rekreacji Dzielnicy Ochota",
                    Description = "",
                    Adress = "Nowowiejska 37B, 02-079 Warszawa",
                    City = Cities.Warszawa.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 4,
                    Name = "OSiR Praga-Południe: Hala Sportowa Siennicka",
                    Description = "",
                    Adress = "Siennicka 40B, 04-393 Warszawa",
                    City = Cities.Warszawa.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 5,
                    Name = "OSiR Targówek Hala Sportowa",
                    Description = "",
                    Adress = "Michała Ossowskiego 25, 03-542 Warszawa",
                    City = Cities.Warszawa.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 6,
                    Name = "Hala Sportowa, Uniwersytet Rolniczy w Krakowie",
                    Description = "",
                    Adress = "al. 29 Listopada 58, 31-425 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 7,
                    Name = "Centrum Sportu i Rekreacji Politechniki Krakowskiej",
                    Description = "",
                    Adress = "Kamienna 17, 30-001 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 8,
                    Name = "Hala sportowa przy IX LO",
                    Description = "",
                    Adress = "Kazimierza Czapińskiego 5, 30-048 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 9,
                    Name = "Hala Sportowa Orzeł Piaski Wielkie",
                    Description = "",
                    Adress = "Niebieska 15, 30-685 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 10,
                    Name = "Hala 100-lecia KS Cracovia wraz z Centrum Sportu Niepełnosprawnych",
                    Description = "",
                    Adress = "Aleja Marszałka Ferdynanda Focha 40, 30-119 Kraków",
                    City = Cities.Krakow.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 11,
                    Name = "KKT Wrocław Stowarzyszenie Krzycki Klub Tenisowy",
                    Description = "",
                    Adress = "ul. Pułtuska 13, 53-116 Wrocław",
                    City = Cities.Wroclaw.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 12,
                    Name = "Hala tenisowa i korty tenisowe AWF",
                    Description = "",
                    Adress = "ul. Paderewskiego 35",
                    City = Cities.Wroclaw.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 13,
                    Name = "Centrum sportowe Hasta La Vista",
                    Description = "",
                    Adress = "ul. Góralska 5",
                    City = Cities.Wroclaw.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 14,
                    Name = "Centrum sportu i rekreacji Sportwerk",
                    Description = "",
                    Adress = "ul. Kozanowska 69",
                    City = Cities.Wroclaw.ToString(),
                    ObjectType = ObjectTypes.Hall.ToString()
                });

            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 1,
                    Name = "",
                    Description = "Desc 1",
                    Price = 20.0m,
                    AmountOfPlayers = 12,
                    Time = 60,
                    DateWhen = DateTime.Now,
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football.ToString(),
                    SkillLevel = SkillLevel.Amateur.ToString(),
                    ObjectId = 14
                });
            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 2,
                    Name = "",
                    Description = "Desc 2",
                    Price = 22.0m,
                    AmountOfPlayers = 6,
                    Time = 30,
                    DateWhen = DateTime.Now,
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football.ToString(),
                    SkillLevel = SkillLevel.Amateur.ToString(),
                    ObjectId = 4
                });
            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 3,
                    Name = "",
                    Description = "Desc 3",
                    Price = 23.0m,
                    AmountOfPlayers = 10,
                    Time = 120,
                    DateWhen = DateTime.Now,
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football.ToString(),
                    SkillLevel = SkillLevel.Amateur.ToString(),
                    ObjectId = 12
                });

            modelBuilder.Entity<TopObjectsEntity>().HasData(
                new TopObjectsEntity() 
                {Id = 1,
                Points = 90,
                ObjectId = 12},
                new TopObjectsEntity()
                {
                    Id = 2,
                    Points = 21,
                    ObjectId = 13
                },
                new TopObjectsEntity()
                {
                    Id = 3,
                    Points = 66,
                    ObjectId = 14
                });
        }
    }
}

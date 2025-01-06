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
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SportEventEntity> SportEvents { get; set; }
        public DbSet<EventAssignersEntity> EventAssigners { get; set; }

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

           // modelBuilder.Entity<SportEventEntity>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<ObjectEntity>()
                .Property(e => e.ObjectType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ObjectTypes)Enum.Parse(typeof(ObjectTypes), v));

            modelBuilder.Entity<ObjectEntity>()
                .Property(e => e.City)
                .HasConversion(
                    v => v.ToString(),
                    v => (Cities)Enum.Parse(typeof(Cities), v));

            modelBuilder.Entity<SportEventEntity>()
                .Property(e => e.Discipline)
                .HasConversion(
                    v => v.ToString(),
                    v => (Disciplines)Enum.Parse(typeof(Disciplines), v));

            modelBuilder.Entity<SportEventEntity>()
                .HasOne(se => se.User)
                .WithMany()
                .HasForeignKey(se => se.CreatedBy)
                .HasPrincipalKey(u => u.UserName)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ObjectEntity>()
                 .HasOne(se => se.User)
                 .WithMany()
                 .HasForeignKey(se => se.CreatedBy)
                 .HasPrincipalKey(u => u.UserName)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SportEventEntity>()
                .HasOne(se => se.Object)
                .WithMany(o => o.SportEvents)
                .HasForeignKey(se => se.ObjectId)
                .OnDelete(DeleteBehavior.NoAction); 




            modelBuilder.Entity<SportEventEntity>()
                .Property(e => e.SkillLevel)
                .HasConversion(
                    v => v.ToString(),
                    v => (SkillLevel)Enum.Parse(typeof(SkillLevel), v));

            modelBuilder.Entity<ObjectEntity>()
                .HasMany(x => x.SportEvents)
                .WithOne(x => x.Object);

            modelBuilder.Entity<EventAssignersEntity>()
                .HasOne(x => x.SportEvent);
                

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


            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = "6a4f2cab-fba0-4634-b4fd-3d87b8bd5612",
                    UserName = "myuser@email.com",
                    Email = "myuser@email.com",
                    NormalizedUserName = "MYUSER@EMAIL.COM",
                    NormalizedEmail = "MYUSER@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Test123!"),
                    Money = 100
                },
                new UserEntity
                {
                    Id = "d3e7c295-d723-4d8e-8c39-be6107f44020",
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    NormalizedUserName = "ADMIN@EMAIL.COM",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Test123!"),
                    Money = 100
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
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 2,
                    Name = "III Ogród Jordanowski",
                    Description = "",
                    Adress = "Wawelska 3, 02-034 Warszawa",
                    City = Cities.Warszawa,
                    ObjectType = ObjectTypes.Sports_field,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 3,
                    Name = "Ośrodek Sportu i Rekreacji Dzielnicy Ochota",
                    Description = "",
                    Adress = "Nowowiejska 37B, 02-079 Warszawa",
                    City = Cities.Warszawa,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 4,
                    Name = "OSiR Praga-Południe: Hala Sportowa Siennicka",
                    Description = "",
                    Adress = "Siennicka 40B, 04-393 Warszawa",
                    City = Cities.Warszawa,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 5,
                    Name = "OSiR Targówek Hala Sportowa",
                    Description = "",
                    Adress = "Michała Ossowskiego 25, 03-542 Warszawa",
                    City = Cities.Warszawa,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 6,
                    Name = "Hala Sportowa, Uniwersytet Rolniczy w Krakowie",
                    Description = "",
                    Adress = "al. 29 Listopada 58, 31-425 Kraków",
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 7,
                    Name = "Centrum Sportu i Rekreacji Politechniki Krakowskiej",
                    Description = "",
                    Adress = "Kamienna 17, 30-001 Kraków",
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 8,
                    Name = "Hala sportowa przy IX LO",
                    Description = "",
                    Adress = "Kazimierza Czapińskiego 5, 30-048 Kraków",
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 9,
                    Name = "Hala Sportowa Orzeł Piaski Wielkie",
                    Description = "",
                    Adress = "Niebieska 15, 30-685 Kraków",
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 10,
                    Name = "Hala 100-lecia KS Cracovia wraz z Centrum Sportu Niepełnosprawnych",
                    Description = "",
                    Adress = "Aleja Marszałka Ferdynanda Focha 40, 30-119 Kraków",
                    City = Cities.Krakow,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 11,
                    Name = "KKT Wrocław Stowarzyszenie Krzycki Klub Tenisowy",
                    Description = "",
                    Adress = "ul. Pułtuska 13, 53-116 Wrocław",
                    City = Cities.Wroclaw,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 12,
                    Name = "Hala tenisowa i korty tenisowe AWF",
                    Description = "",
                    Adress = "ul. Paderewskiego 35",
                    City = Cities.Wroclaw,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 13,
                    Name = "Centrum sportowe Hasta La Vista",
                    Description = "",
                    Adress = "ul. Góralska 5",
                    City = Cities.Wroclaw,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });
            modelBuilder.Entity<ObjectEntity>().HasData(
                new ObjectEntity()
                {
                    Id = 14,
                    Name = "Centrum sportu i rekreacji Sportwerk",
                    Description = "",
                    Adress = "ul. Kozanowska 69",
                    City = Cities.Wroclaw,
                    ObjectType = ObjectTypes.Hall,
                    CreatedBy = "myuser@email.com",
                    PricePerHour = 200
                });

            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 1,
                    Name = "",
                   // Price = 20.0m,
                    AmountOfPlayers = 12,
                    Time = 1,
                    DateWhen = DateTime.Now.AddYears(2),
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football,
                    SkillLevel = SkillLevel.Amateur,
                    ObjectId = 14,
                    IsMultiSportCard = true
                });
            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 2,
                    Name = "",
                    //Price = 22.0m,
                    AmountOfPlayers = 6,
                    Time = 1,
                    DateWhen = DateTime.Now.AddYears(2),
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football,
                    SkillLevel = SkillLevel.Amateur,
                    ObjectId = 4,
                    IsMultiSportCard = true
                });
            modelBuilder.Entity<SportEventEntity>().HasData(
                new SportEventEntity()
                {
                    Id = 3,
                    Name = "",
                    //Price = 23.0m,
                    AmountOfPlayers = 10,
                    Time = 1,
                    DateWhen = DateTime.Now.AddYears(2),
                    CreatedBy = "myuser@email.com",
                    Discipline = Disciplines.Football,
                    SkillLevel = SkillLevel.Amateur,
                    ObjectId = 12,
                    IsMultiSportCard = false
                });
        }
    }
}

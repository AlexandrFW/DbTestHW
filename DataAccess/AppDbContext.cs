using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace DbTestHW.DataAccess;

internal class AppDbContext : DbContext
{
    static bool _isDatabaseCreated = false;

    public DbSet<UserDto> Users { get; set; }

    public DbSet<AnnouncementDto> Announcements { get; set; }

    public DbSet<CategoryDto> Categories { get; set; }

    public DbSet<UserAnnouncementDto> UsersAnnouncements { get; set; }

    public  AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        if (!_isDatabaseCreated)
        {
            DataBaseRecreation();

            _isDatabaseCreated = true;
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Debug.WriteLine("SeedDatabase(modelBuilder);");
        SeedDatabase(modelBuilder);
    }

    private void DataBaseRecreation()
    {
        Debug.WriteLine("Database.EnsureDeleted();");
        Database.EnsureDeleted();

        Debug.WriteLine("Database.EnsureCreated();");
        Database.EnsureCreated();
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        var users = new UserDto[]
        {
            new UserDto
            {
                UserId = 1,
                Name = "Иван Петров",
                Email= "ivan.petrov@gmail.com",
                Phone = "+79001234321",
                Password = "123"                
            },
            new UserDto
            {
                UserId = 2,
                Name = "Дмитрий Антонов",
                Email= "dmitry.antonov@yandex.ru",
                Phone = "+79651437391",
                Password = "123"
            },
            new UserDto
            {
                UserId = 3,
                Name = "Анатолий Сидоров",
                Email= "anatoly.sidorov@yandex.ru",
                Phone = "+79013437995",
                Password = "123"
            },
            new UserDto
            {
                UserId = 4,
                Name = "Павел Дмитриев",
                Email= "pavel.dmitriev@gmail.com",
                Phone = "+791275423905",
                Password = "123"
            },
            new UserDto
            {
                UserId = 5,
                Name = "Андрей Вавилов",
                Email= "andrey.vavilov@gmail.com",
                Phone = "+79870091765",
                Password = "123"
            }
        };

        var categories = new CategoryDto[]
        {
            new CategoryDto
            {
                CategoryId = 1,
                CategoryName = "Недвижимость"
            },
            new CategoryDto
            {
                CategoryId = 2,
                CategoryName = "Автомобили"
            },
            new CategoryDto
            {
                CategoryId = 3,
                CategoryName = "Спорт товары"
            },
            new CategoryDto
            {
                CategoryId = 4,
                CategoryName = "Аудо-Видео Оборудование"
            }
        };

        var announcementDto = new AnnouncementDto[]
        {
            new AnnouncementDto
            {
                AnnouncementId = 1,
                CategoryId = categories[2].CategoryId,
                Title = "Штанга",
                Description = "Продаётся штанга, 50 кг + гантели 2х5кг в подарок",
                Price = 12000,
                IsPayed = false,
                IsVip = false
            },
            new AnnouncementDto
            {
                AnnouncementId = 2,
                CategoryId = categories[1].CategoryId,
                Title = "Toyota Rav 4, 2010",
                Description = "Продаётся автомобил Toyota Rav 4, 2010. Не бита, не крашена, перед продажей налимонена",
                Price = 900000,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                AnnouncementId = 3,
                CategoryId = categories[3].CategoryId,
                Title = "Видеокамера Panasonic",
                Description = "Продаётся видеокамера Panasonic. Использовалась часто для профессиональной съёмки. Состояние хорошое.",
                Price = 25000,
                IsPayed= true,
                IsVip = false
            },
            new AnnouncementDto
            {
                AnnouncementId = 4,
                CategoryId = categories[0].CategoryId,
                Title = "Продаётся загородный дом, 170м2",
                Description = "Продаётся загородный дом, ижс, 170м2, санузел в доме, в 10 минутах езды до города",
                Price = 2900000,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                AnnouncementId = 5,
                CategoryId = categories[3].CategoryId,
                Title = "Продаётся фотоаппарат Зенит",
                Description = "Продаётся фотоаппарат Зенит. Состояние отличное. Все вопросы по телефону",
                Price = 30500,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                AnnouncementId = 6,
                CategoryId = categories[1].CategoryId,
                Title = "Автомобиль ВАЗ 2101, 1975",
                Description = "Продаётся автомобиль ВАЗ 2101, 1975 года выпуска, на ходу, ухоженный, гаражное хранение, не гнилой",
                Price = 50000,
                IsPayed = false,
                IsVip = false
            },
            new AnnouncementDto
            {
                AnnouncementId = 7,
                CategoryId = categories[3].CategoryId,
                Title = "Телескоп Грендаль2000",
                Description = "Телескоп Грендаль2000, разрешение достаточное, чтобы разглядеть инопланетян на Луне",
                Price = 15000,
                IsPayed= false,
                IsVip = false
            }
        };

        var usersAnnouncements = new UserAnnouncementDto[]
        {
            new UserAnnouncementDto
            {
                 AnnouncementId = 1,
                 UserId = users[0].UserId
            },
            new UserAnnouncementDto
            {
                 AnnouncementId = 2,
                 UserId = users[2].UserId
            },
            new UserAnnouncementDto
            {
                 AnnouncementId = 3,
                 UserId = users[3].UserId
            },
            new UserAnnouncementDto
            {
                 AnnouncementId = 4,
                 UserId = users[0].UserId
            },
             new UserAnnouncementDto
            {
                 AnnouncementId = 5,
                 UserId = users[3].UserId
            },
            new UserAnnouncementDto
            {
                 AnnouncementId = 6,
                 UserId = users[4].UserId
            },
            new UserAnnouncementDto
            {
                 AnnouncementId = 7,
                 UserId = users[2].UserId
            }
        };

        modelBuilder.ApplyConfiguration(new UsersAnnouncementsDtoConfiguration());

        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<CategoryDto>().HasData(categories);
        modelBuilder.Entity<AnnouncementDto>().HasData(announcementDto);
        modelBuilder.Entity<UserAnnouncementDto>().HasData(usersAnnouncements);
    }

    // Many-to-Many Relationship configuration between Users and Announcements entities
    internal class UsersAnnouncementsDtoConfiguration : IEntityTypeConfiguration<UserAnnouncementDto>
    {
        public void Configure(EntityTypeBuilder<UserAnnouncementDto> builder)
        {
            builder.HasKey(s => new { s.AnnouncementId, s.UserId });

            builder.HasOne(u => u.User)
                   .WithMany(s => s.UsersAnnouncements)
                   .HasForeignKey(ss => ss.UserId);

            builder.HasOne(ss => ss.Announcement)
                   .WithMany(s => s.UsersAnnouncements)
                   .HasForeignKey(ss => ss.AnnouncementId);
        }
    }
}
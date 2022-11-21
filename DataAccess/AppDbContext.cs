using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbTestHW.DataAccess;

internal class AppDbContext : DbContext
{
    static bool _isDatabaseCreated = false;

    DbSet<UserDto> Users { get; set; }

    DbSet<AnnouncementDto> Announcements { get; set; }

    DbSet<CategoryDto> Categories { get; set; }

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        if (!_isDatabaseCreated)
        {
            DataBaseRecreation();

            _isDatabaseCreated = true;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedDatabase(modelBuilder);
    }

    private void DataBaseRecreation()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        var users = new UserDto[]
        {
            new UserDto
            {
                UserId = Guid.NewGuid(),
                Name = "Иван Петров",
                Email= "ivan.petrov@gmail.com",
                Phone = "+79001234321",
                Password = "123"                
            },
            new UserDto
            {
                UserId = Guid.NewGuid(),
                Name = "Дмитрий Антонов",
                Email= "dmitry.antonov@yandex.ru",
                Phone = "+79651437391",
                Password = "123"
            },
            new UserDto
            {
                UserId = Guid.NewGuid(),
                Name = "Анатолий Сидоров",
                Email= "anatoly.sidorov@yandex.ru",
                Phone = "+79013437995",
                Password = "123"
            },
            new UserDto
            {
                UserId = Guid.NewGuid(),
                Name = "Павел Дмитриев",
                Email= "pavel.dmitriev@gmail.com",
                Phone = "+791275423905",
                Password = "123"
            },
            new UserDto
            {
                UserId = Guid.NewGuid(),
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
                CategoryId= Guid.NewGuid(),
                CategoryName = "Недвижимость"
            },
            new CategoryDto
            {
                CategoryId= Guid.NewGuid(),
                CategoryName = "Автомобили"
            },
            new CategoryDto
            {
                CategoryId= Guid.NewGuid(),
                CategoryName = "Спорт товары"
            },
            new CategoryDto
            {
                CategoryId= Guid.NewGuid(),
                CategoryName = "Аудо-Видео Оборудование"
            }
        };

        var announcementDto = new AnnouncementDto[]
        {
            new AnnouncementDto
            {
                UserId = users[0].UserId,
                CategoryId = categories[2].CategoryId,
                Title = "Штанга",
                Description = "Продаётся штанга, 50 кг + гантели 2х5кг в подарок",
                Price = 12000,
                IsPayed = false,
                IsVip = false
            },
            new AnnouncementDto
            {
                UserId = users[2].UserId,
                CategoryId = categories[1].CategoryId,
                Title = "Toyota Rav 4, 2010",
                Description = "Продаётся автомобил Toyota Rav 4, 2010. Не бита, не крашена, перед продажей налимонена",
                Price = 900000,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                UserId = users[3].UserId,
                CategoryId = categories[3].CategoryId,
                Title = "Видеокамера Panasonic",
                Description = "Продаётся видеокамера Panasonic. Использовалась часто для профессиональной съёмки. Состояние хорошое.",
                Price = 25000,
                IsPayed= true,
                IsVip = false
            },
            new AnnouncementDto
            {
                UserId = users[0].UserId,
                CategoryId = categories[0].CategoryId,
                Title = "Продаётся загородный дом, 170м2",
                Description = "Продаётся загородный дом, ижс, 170м2, санузел в доме, в 10 минутах езды до города",
                Price = 2900000,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                UserId = users[4].UserId,
                CategoryId = categories[3].CategoryId,
                Title = "Продаётся фотоаппарат Зенит",
                Description = "Продаётся фотоаппарат Зенит. Состояние отличное. Все вопросы по телефону",
                Price = 30500,
                IsPayed= true,
                IsVip = true
            },
            new AnnouncementDto
            {
                UserId = users[4].UserId,
                CategoryId = categories[1].CategoryId,
                Title = "Автомобиль ВАЗ 2101, 1975",
                Description = "Продаётся автомобиль ВАЗ 2101, 1975 года выпуска, на ходу, ухоженный, гаражное хранение, не гнилой",
                Price = 50000,
                IsPayed = false,
                IsVip = false
            },
            new AnnouncementDto
            {
                UserId = users[3].UserId,
                CategoryId = categories[4].CategoryId,
                Title = "Телескоп Грендаль2000",
                Description = "Телескоп Грендаль2000, разрешение достаточное, чтобы разглядеть инопланетян на Луне",
                Price = 15000,
                IsPayed= false,
                IsVip = false
            }
        };

        modelBuilder.ApplyConfiguration(new AnnouncementDtoConfiguration());

        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<CategoryDto>().HasData(categories);
        modelBuilder.Entity<AnnouncementDto> ().HasData(announcementDto);
    }

    // Relationships configurations
    internal class AnnouncementDtoConfiguration : IEntityTypeConfiguration<AnnouncementDto>
    {
        public void Configure(EntityTypeBuilder<AnnouncementDto> builder)
        {
            builder.HasKey(s => new { s.UserId, s.CategoryId });

            builder.HasOne(ss => ss.User)
                   .WithMany(s => s.Announcements)
                   .HasForeignKey(ss => ss.UserId);

            builder.HasOne(ss => ss.Category)
                   .WithMany(s => s.Announcements)
                   .HasForeignKey(ss => ss.CategoryId);
        }
    }
}
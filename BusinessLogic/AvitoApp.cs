using AutoMapper;
using DbTestHW.DataAccess;
using DbTestHW.DataAccess.Repositories;
using DbTestHW.Domain;
using Microsoft.EntityFrameworkCore;

namespace DbTestHW.BusinessLogic;

public class AvitoApp
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;

    private readonly UserRepository userRepository;
    private readonly CategoriesRepository categoryRepository;
    private readonly AnnouncementsRepository announcementRepository;

    public AvitoApp(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var options = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;

        _appDbContext = new AppDbContext(options);

        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MapperProfile>();
        });
        _mapper = config.CreateMapper(); 

        userRepository = new UserRepository(_appDbContext, _mapper);
        categoryRepository = new CategoriesRepository(_appDbContext, _mapper);
        announcementRepository = new AnnouncementsRepository(_appDbContext, _mapper);
    }

    public User? AddNewUser(User user)
    {
        if (userRepository is not null)
            return userRepository.AddItem(user);
        else
            return null;
    }

    public List<User?> GetAllUsers()
    {
        if (userRepository is not null)
            return userRepository.GetCollection();
        else
            return (List<User?>)Enumerable.Empty<User>();
    }

    public List<Category?> GetAllCategories()
    {
        if (categoryRepository is not null)
            return categoryRepository.GetCollection();
        else
            return (List<Category?>)Enumerable.Empty<Category>();
    }

    public List<Announcement?> GetAllAnnouncements()
    {
        if (announcementRepository is not null)
            return announcementRepository.GetCollection();
        else
            return (List<Announcement?>)Enumerable.Empty<Announcement>();
    }
}

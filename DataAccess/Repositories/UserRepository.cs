using AutoMapper;
using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;
using DbTestHW.Domain.Interfaces.Repositories;

namespace DbTestHW.DataAccess.Repositories;

internal class UserRepository : IRepository<User>
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public User AddItem(User item)
    {
        var user = _mapper.Map<UserDto>(item);
        var userId = _appDbContext.Users.Add(user);

        _appDbContext.SaveChangesAsync();

        return GetById(userId.Entity.UserId);
    }

    public void DeleteItem(int id)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.UserId == id);

        if (user is not null)
        {
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChangesAsync();
        }
    }

    public User? EditItem(User item)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.UserId == item.UserId);

        if (user is not null)
        {
            user.Email = item.Email;
            user.Phone = item.Phone;

            _appDbContext.Users.Update(user);
        }

        return null;
    }

    public User? GetById(int id)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.UserId == id);

        if (user is not null)
        {
            return _mapper.Map<User>(user);
        }

        return null;
    }

    public List<User?> GetCollection()
    {
        var users = _appDbContext.Users.ToList();

        if (users is not null)
            return _mapper.Map<List<User>>(users);
        else
            return (List<User?>)Enumerable.Empty<User>();
    }
}
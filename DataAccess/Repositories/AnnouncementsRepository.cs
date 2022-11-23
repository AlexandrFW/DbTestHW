using AutoMapper;
using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;
using DbTestHW.Domain.Interfaces.Repositories;

namespace DbTestHW.DataAccess.Repositories;

internal class AnnouncementsRepository : IRepository<Announcement>
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public AnnouncementsRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public Announcement? AddItem(Announcement item)
    {
        //var announcement = _mapper.Map<AnnouncementDto>(item);
        //var announcementAdded = _appDbContext.Announcements.Add(announcement);

        //_appDbContext.SaveChangesAsync();

        //return GetById(announcementAdded.Entity.CategoryId);

        throw new NotImplementedException();
    }

    public void DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public Announcement? EditItem(Announcement item)
    {
        throw new NotImplementedException();
    }

    public Announcement? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Announcement?> GetCollection()
    {
        var announcements = _appDbContext.Announcements.ToList();

        if (announcements is not null)
            return _mapper.Map<List<Announcement>>(announcements);
        else
            return (List<Announcement?>)Enumerable.Empty<Announcement>();
    }
}
using AutoMapper;
using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;
using DbTestHW.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

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
        var announcements = from ua in _appDbContext.UsersAnnouncements
                            join us in _appDbContext.Users on ua.UserId equals us.UserId 
                            join an in _appDbContext.Announcements on ua.AnnouncementId equals an.AnnouncementId                            
                            join ctg in _appDbContext.Categories on an.CategoryId equals ctg.CategoryId                              
                            select new Announcement
                            {
                                AnnouncementId = ua.AnnouncementId,
                                CategoryId = ctg.CategoryId,
                                CategoryName = ctg.CategoryName, 
                                Title = an.Title, 
                                Description = an.Description, 
                                Price = an.Price, 
                                IsPayed = an.IsPayed, 
                                IsVip = an.IsVip, 
                                Created = an.Created,
                                UserId = us.UserId,
                                UserName = us.Name,
                                Email = us.Email,
                                Phone = us.Phone
                            };

        if (announcements is not null)
            return announcements!.ToList(); // _mapper.Map<List<AnnouncementDto>>(announcements)!;
        else
            return (List<Announcement?>)Enumerable.Empty<Announcement>();
            
    }
}
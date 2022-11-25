using AutoMapper;
using DbTestHW.DataAccess.Dto;
using DbTestHW.Domain;

namespace DbTestHW.DataAccess;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<CategoryDto, Category>().ReverseMap();

        //CreateMap<AnnouncementDto, Announcement>()
        //    .ForMember(dto => dto.AnnouncementId, opt => opt.MapFrom(x => x.UsersAnnouncements.Select(y => y.Announcement).ToList()));

        //CreateMap<List<AnnouncementDto>, List<Announcement>>();

        CreateMap<UserAnnouncementDto, UserAnnouncement>().ReverseMap();
    }
}
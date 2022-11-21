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

        CreateMap<AnnouncementDto, Announcement>()
                .ForMember(ann => ann.UserName, opt => opt.MapFrom(src => src.User!.Name))
                .ForMember(ueml => ueml.Email, opt => opt.MapFrom(src => src.User!.Email))
                .ForMember(phn => phn.Phone, opt => opt.MapFrom(src => src.User!.Phone))
                .ForMember(cat => cat.CategoryName, opt => opt.MapFrom(src => src.Category!.CategoryName))
                .IncludeMembers(s => s.User);

        CreateMap<Announcement, AnnouncementDto>()
                .ForMember(ann => ann.User!.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(ueml => ueml.User!.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(phn => phn.User!.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(cat => cat.Category!.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(prc => prc.Price, opt => opt.MapFrom(src => src.Price));
    }
}
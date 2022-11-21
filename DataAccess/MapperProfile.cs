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


    }
}
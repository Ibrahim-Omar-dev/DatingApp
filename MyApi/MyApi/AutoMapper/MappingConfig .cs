using AutoMapper;
using MyApi.Entities;
using MyApi.Entities.Dto.UserDto;

namespace MyApi.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}

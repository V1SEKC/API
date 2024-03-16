using API.Dto;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Apontment, ApontmentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Computer, ComputerDto>().ReverseMap();
        }
    }
}

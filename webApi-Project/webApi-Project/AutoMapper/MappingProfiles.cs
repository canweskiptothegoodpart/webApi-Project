using AutoMapper;
using webApi_Project.Dto;
using webApi_Project.Models;

namespace webApi_Project.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}

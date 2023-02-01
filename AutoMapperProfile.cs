using ApiProject.DTOs.Character;
using ApiProject.Models;
using AutoMapper;
namespace ApiProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
        }
    }
}
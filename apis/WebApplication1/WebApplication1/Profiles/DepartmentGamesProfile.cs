using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class DepartmentGamesProfile : Profile
    {
        public DepartmentGamesProfile()
        {
            CreateMap<DepartmentGame, DepartmentGameDto>();
            CreateMap<DepartmentGameDto, DepartmentGame>();
        }
    }
}

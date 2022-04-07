using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class EmployeeGamesProfile : Profile
    {
        public EmployeeGamesProfile()
        {
            CreateMap<EmployeeGame, EmployeeGameDto>();
            CreateMap<EmployeeGameDto, EmployeeGame>();
            CreateMap<EmployeeGame, EmployeeGameForCreationDto>();
            CreateMap<EmployeeGameForCreationDto, EmployeeGame>();
        }
    }
}

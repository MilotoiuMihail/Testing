using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/departments/{departmentId}/employees/{employeeId}/[controller]")]
    [ApiController]
    public class EmployeeGamesController : ControllerBase
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IMapper _mapper;

        public EmployeeGamesController(IUtilitiesRepository utilitiesRepository, IMapper mapper)
        {
            _utilitiesRepository = utilitiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesFromEmployee(int departmentId, int employeeId)
        {
            if (!(await _utilitiesRepository.DepartmentExistsAsync(departmentId) && await _utilitiesRepository.EmployeeExistsAsync(employeeId)))
            {
                return NotFound();
            }
            var employeeGamesFromRepo = await _utilitiesRepository.GetEmployeeGamesAsync(employeeId);
            return Ok(_mapper.Map<IEnumerable<EmployeeGameDto>>(employeeGamesFromRepo));
        }

        //[HttpGet("{gameId}")]
        //public async Task<IActionResult> GetEmployeeGameById(int employeeId, int gameId)
        //{
        //    if (!(await _utilitiesRepository.EmployeeExistsAsync(employeeId) && await _utilitiesRepository.GameExistsAsync(gameId)))
        //    {
        //        return NotFound();
        //    }

        //    var employeeGameFromRepo = await _utilitiesRepository.GetEmployeeGameAsync(employeeId, gameId);

        //    if (employeeGameFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<EmployeeGameDto>(employeeGameFromRepo));
        //}

        [HttpPost]
        public async Task<ActionResult<EmployeeGameDto>> CreateEmployeeGame(EmployeeGameForCreationDto employeeGame) //GameForCreationDto
        {
            var employeeGameEntity = _mapper.Map<EmployeeGame>(employeeGame);
            _utilitiesRepository.AddEmployeeGame(employeeGameEntity);
            await _utilitiesRepository.SaveAsync();

            var employeeGameToReturn = _mapper.Map<EmployeeGameDto>(employeeGameEntity);

            return employeeGameToReturn;//?
        }

        [HttpDelete("{gameId}")]
        public async Task<ActionResult> DeleteEmployeeGame(int employeeId,int gameId)
        {
            var employeeGameFromRepo = await _utilitiesRepository.GetEmployeeGameAsync(employeeId,gameId);

            if (employeeGameFromRepo == null)
            {
                return NotFound();
            }

            _utilitiesRepository.DeleteEmployeeGame(employeeGameFromRepo);
            await _utilitiesRepository.SaveAsync();

            return NoContent();
        }
    }
}

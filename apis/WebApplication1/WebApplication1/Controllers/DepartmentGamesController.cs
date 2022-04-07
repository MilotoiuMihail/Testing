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
    [Route("api/departments/{departmentId}/[controller]")]
    [ApiController]
    public class DepartmentGamesController : ControllerBase
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IMapper _mapper;

        public DepartmentGamesController(IUtilitiesRepository utilitiesRepository, IMapper mapper)
        {
            _utilitiesRepository = utilitiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesFromDepartment(int departmentId)
        {
            if (!await _utilitiesRepository.DepartmentExistsAsync(departmentId))
            {
                return NotFound();
            }
            var departmentGamesFromRepo = await _utilitiesRepository.GetDepartmentGamesAsync(departmentId);
            return Ok(_mapper.Map<IEnumerable<DepartmentGameDto>>(departmentGamesFromRepo));
        }

        //[HttpGet("{gameId}")]
        //public async Task<IActionResult> GetDepartmentGameById(int departmentId, int gameId)
        //{
        //    if (!(await _utilitiesRepository.DepartmentExistsAsync(departmentId) && await _utilitiesRepository.GameExistsAsync(gameId)))
        //    {
        //        return NotFound();
        //    }

        //    var departmentGameFromRepo = await _utilitiesRepository.GetDepartmentGameAsync(departmentId, gameId);

        //    if (departmentGameFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<DepartmentGameDto>(departmentGameFromRepo));
        //}

        [HttpPut("{gameId}")]
        public async Task<ActionResult<DepartmentGameDto>> UpdateDepartmentGame(int departmentId, int gameId, DepartmentGameDto departmentGameForUpdate) //GameForUpdate
        {
            var departmentGame = await _utilitiesRepository.GetDepartmentGameAsync(departmentId, gameId);

            if (departmentGame == null)
            {
                return NotFound();
            }

            var departmentGameEntity = _mapper.Map<DepartmentGame>(departmentGameForUpdate);
            _utilitiesRepository.UpdateDepartmentGame(departmentGameEntity);
            await _utilitiesRepository.SaveAsync();

            return NoContent();
        }
    }
}

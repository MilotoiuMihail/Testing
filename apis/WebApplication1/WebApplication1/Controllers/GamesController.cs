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
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IMapper _mapper;

        public GamesController(IUtilitiesRepository utilitiesRepository, IMapper mapper)
        {
            _utilitiesRepository = utilitiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var gamesFromRepo = await _utilitiesRepository.GetGamesAsync();
            return Ok(_mapper.Map<IEnumerable<GameDto>>(gamesFromRepo));
        }

        //[HttpGet("{gameId}", Name = "GetGame")]
        //public async Task<IActionResult> GetGameById(int gameId)
        //{
        //    var game = await _utilitiesRepository.GetGameAsync(gameId);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(game);
        //}
    }
}

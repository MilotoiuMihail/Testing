using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ProiectContext _context;

        public GamesRepository(ProiectContext proiectContext)
        {
            _context = proiectContext;
        }
        public async Task<Game> GetGameAsync(int gameId)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync<Game>();
        }
    }
}

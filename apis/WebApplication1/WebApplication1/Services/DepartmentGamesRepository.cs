using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class DepartmentGamesRepository : IDepartmentGamesRepository
    {
        private readonly ProiectContext _context;

        public DepartmentGamesRepository(ProiectContext proiectContext)
        {
            _context = proiectContext;
        }

        public async Task<DepartmentGame> GetDepartmentGameAsync(int departmentId, int gameId)
        {
            return await _context.DepartmentGames.FirstOrDefaultAsync(dg => dg.GameId == gameId && dg.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<DepartmentGame>> GetDepartmentGamesAsync(int departmentId)
        {
            return await _context.DepartmentGames
                .Where(d => d.DepartmentId == departmentId)
                .OrderBy(g => g.Game.Name).ToListAsync<DepartmentGame>();
        }

        public void UpdateDepartmentGame(DepartmentGame departmentGame)
        {
            _context.DepartmentGames.Update(departmentGame);
        }
    }
}

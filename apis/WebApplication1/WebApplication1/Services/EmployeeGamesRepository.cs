using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class EmployeeGamesRepository : IEmployeeGamesRepository
    {
        private readonly ProiectContext _context;

        public EmployeeGamesRepository(ProiectContext proiectContext)
        {
            _context = proiectContext;
        }
        public void AddEmployeeGame(EmployeeGame employeeGame)
        {
            if (employeeGame == null)
            {
                throw new ArgumentNullException(nameof(employeeGame));
            }

            _context.EmployeeGames.Add(employeeGame);
        }

        public void DeleteEmployeeGame(EmployeeGame employeeGame)
        {
            if (employeeGame == null)
            {
                throw new ArgumentNullException(nameof(employeeGame));
            }

            _context.EmployeeGames.Remove(employeeGame);
        }

        public async Task<EmployeeGame> GetEmployeeGameAsync(int employeeId, int gameId)
        {
            return await _context.EmployeeGames.FirstOrDefaultAsync(eg => eg.GameId == gameId && eg.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<EmployeeGame>> GetEmployeeGamesAsync(int employeeId)//?
        {
            return await _context.EmployeeGames
                .Where(e => e.EmployeeId == employeeId)
                .OrderBy(g => g.Game.Name).ToListAsync<EmployeeGame>();
        }
    }
}

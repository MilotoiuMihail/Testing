using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UtilitiesRepository : IUtilitiesRepository
    {
        private readonly ProiectContext _context;

        public UtilitiesRepository(ProiectContext proiectContext)
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

        //public void AddGame(Game game)
        //{
        //    if (game == null)
        //    {
        //        throw new ArgumentNullException(nameof(game));
        //    }

        //    _context.Games.Add(game);
        //}

        public void DeleteEmployeeGame(EmployeeGame employeeGame)
        {
            if (employeeGame == null)
            {
                throw new ArgumentNullException(nameof(employeeGame));
            }

            _context.EmployeeGames.Remove(employeeGame);
        }

        //public void DeleteGame(Game game)
        //{
        //    if (game == null)
        //    {
        //        throw new ArgumentNullException(nameof(game));
        //    }

        //    _context.Games.Remove(game);
        //}

        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await _context.Departments.AnyAsync(d => d.Id == departmentId);
        }

        public async Task<bool> EmployeeExistsAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.Id == employeeId);
        }

        //public async Task<bool> EmployeeGameExistsAsync(int employeeId, int gameId)
        //{
        //    return await _context.EmployeeGames.AnyAsync(eg => eg.EmployeeId == employeeId && eg.GameId == gameId);
        //}

        //public async Task<bool> GameExistsAsync(int gameId)
        //{
        //    return await _context.Games.AnyAsync(g => g.Id == gameId);
        //}

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

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync<Department>();
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

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.Department == departmentId)
                .OrderBy(e => e.LastName).ToListAsync();
        }

        //public async Task<Game> GetGameAsync(int gameId)
        //{
        //    return await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
        //}

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync<Game>();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateDepartmentGame(DepartmentGame departmentGame)
        {
            _context.DepartmentGames.Update(departmentGame);
        }

        //public void UpdateEmployeeGame(EmployeeGame employeeGame)
        //{
        //    _context.EmployeeGames.Update(employeeGame);
        //}

        //public void UpdateGame(Game game)
        //{
        //    _context.Games.Update(game);
        //}
    }
}

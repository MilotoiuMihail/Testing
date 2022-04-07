using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IEmployeeGamesRepository
    {
        Task<IEnumerable<EmployeeGame>> GetEmployeeGamesAsync(int employeeId);
        Task<EmployeeGame> GetEmployeeGameAsync(int employeeId, int gameId);
        void AddEmployeeGame(EmployeeGame employeeGame);
        void DeleteEmployeeGame(EmployeeGame employeeGame);
        //Task<bool> EmployeeGameExistsAsync(int employeeId, int gameId);
    }
}

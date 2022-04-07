using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUtilitiesRepository
    {
        //void AddGame(Game game);
        //void DeleteGame(Game game);
        //void UpdateGame(Game game);
        //Task<bool> GameExistsAsync(int gameId);
        //Task<Game> GetGameAsync(int gameId);
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<bool> EmployeeExistsAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId);
        //Task<bool> EmployeeGameExistsAsync(int employeeId, int gameId);
        Task<IEnumerable<EmployeeGame>> GetEmployeeGamesAsync(int employeeId);
        Task<EmployeeGame> GetEmployeeGameAsync(int employeeId, int gameId);
        void AddEmployeeGame(EmployeeGame employeeGame);
        void DeleteEmployeeGame(EmployeeGame employeeGame);
        //void UpdateEmployeeGame(EmployeeGame employeeGame);
        Task<IEnumerable<DepartmentGame>> GetDepartmentGamesAsync(int departmentId);
        Task<DepartmentGame> GetDepartmentGameAsync(int departmentId, int gameId);
        void UpdateDepartmentGame(DepartmentGame departmentGame);
        Task<bool> SaveAsync();
    }
}

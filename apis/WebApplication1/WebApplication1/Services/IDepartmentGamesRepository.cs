using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IDepartmentGamesRepository
    {
        Task<IEnumerable<DepartmentGame>> GetDepartmentGamesAsync(int departmentId);
        Task<DepartmentGame> GetDepartmentGameAsync(int departmentId, int gameId);
        void UpdateDepartmentGame(DepartmentGame departmentGame);
    }
}

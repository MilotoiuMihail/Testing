using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IDepartmentsRepository
    {
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<IEnumerable<Department>> GetDepartmentsAsync();
    }
}

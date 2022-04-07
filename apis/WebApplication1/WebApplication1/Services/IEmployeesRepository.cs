using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IEmployeesRepository
    {
        Task<bool> EmployeeExistsAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId);
    }
}

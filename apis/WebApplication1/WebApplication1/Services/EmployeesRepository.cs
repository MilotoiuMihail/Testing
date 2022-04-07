using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ProiectContext _context;

        public EmployeesRepository(ProiectContext proiectContext)
        {
            _context = proiectContext;
        }
        public async Task<bool> EmployeeExistsAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.Department == departmentId)
                .OrderBy(e => e.LastName).ToListAsync();
        }
    }
}

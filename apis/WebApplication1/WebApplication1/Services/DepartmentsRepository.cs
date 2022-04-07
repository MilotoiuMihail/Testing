using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly ProiectContext _context;

        public DepartmentsRepository(ProiectContext proiectContext)
        {
            _context = proiectContext;
        }
        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await _context.Departments.AnyAsync(d => d.Id == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync<Department>();
        }
    }
}

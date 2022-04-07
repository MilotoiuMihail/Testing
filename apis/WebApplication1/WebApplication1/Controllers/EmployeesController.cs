using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/departments/{departmentId}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IUtilitiesRepository utilitiesRepository, IMapper mapper)
        {
            _utilitiesRepository = utilitiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesFromDepartment(int departmentId)
        {
            if (!await _utilitiesRepository.DepartmentExistsAsync(departmentId))
            {
                return NotFound();
            }
            var employeesFromRepo = await _utilitiesRepository.GetEmployeesAsync(departmentId);
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo));
        }
    }
}

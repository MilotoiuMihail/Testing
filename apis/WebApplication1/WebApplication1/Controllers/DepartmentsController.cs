using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IUtilitiesRepository utilitiesRepository,IMapper mapper)
        {
            _utilitiesRepository=utilitiesRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departmentsFromRepo = await _utilitiesRepository.GetDepartmentsAsync();
            return Ok(_mapper.Map<IEnumerable<DepartmentDto>>(departmentsFromRepo));
        }
    }
}

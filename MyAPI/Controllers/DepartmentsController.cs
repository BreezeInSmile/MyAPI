using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using MyAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentRepository>>> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            if (!departments.Any())
            {
                return NoContent();
            }

            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Add([FromBody]Department model)
        {
            var temp = await _departmentRepository.Add(model);

            return Ok(temp);
        }
    }
}

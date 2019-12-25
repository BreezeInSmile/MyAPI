using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using MyAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetByDepartmentId(int departmentId)
        {
            var employees = await _employeeRepository.GetByDepartmentId(departmentId);
            if (!employees.Any())
            {
                return NoContent();
            }

            return Ok(employees);
        }

        [HttpGet("One/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeRepository.GetById(id);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Employee model)
        {
            var temp = await _employeeRepository.add(model);
            return CreatedAtRoute("GetById", new { id = temp.Id }, temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Fire(int id)
        {
            var result = await _employeeRepository.Fired(id);

            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}

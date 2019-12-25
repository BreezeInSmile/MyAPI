using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> Fired(int id);
        Task<IEnumerable<Employee>> GetById(int id);
    }
}

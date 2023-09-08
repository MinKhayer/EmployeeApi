using EmployeeApi.Context;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HierarchyController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;

        public HierarchyController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/employees/hierarchy")]
        public async Task<IActionResult> GetHierarchy(int employeeId)
        {
           
            var employee = await _dbContext.Employees.FindAsync(employeeId);

            
            if (employee == null)
            {
                return Ok(new List<Employee>());
            }

            
            var hierarchy = new List<Employee>();

            
            hierarchy.Add(employee);

           
            var supervisor = employee.supervisorId;

            
            while (supervisor != null)
            {
                employee = await _dbContext.Employees.FindAsync(supervisor);
                hierarchy.Add(employee);
                supervisor = employee.supervisorId;
            }

            /
            return Ok(hierarchy);
        }
    }
}


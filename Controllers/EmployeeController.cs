using EmployeeApi.Context;
using EmployeeApi.Interfaces.Manager;
using EmployeeApi.Manager;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbContext _dbContext;
        IEmployeeManager _employeeManager;
        public EmployeeController(EmployeeDbContext dbContext) 
        { 
            _dbContext = dbContext;
            _employeeManager=new EmployeeManager(dbContext);
        }

        //public EmployeeController(IEmployeeManager employeeManager)
        //{
        //    _employeeManager = employeeManager;
        //}

        [HttpGet]
        public ActionResult<List<Employee>>GetAll()
        {
            //var employees = _dbContext.Employees.ToList();
            var employees =_employeeManager.GetAll().ToList();
            return Ok(employees);
        }
        [HttpGet]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = _employeeManager.GetById(id);
            if(employee == null) 
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult<Employee> Add(Employee employee)
        {
           bool isSaved=_employeeManager.Add(employee);
            //_dbContext.Employees.Add(employee);
            //bool isSaved=_dbContext.SaveChanges()>0;
            if (isSaved)
            {
                return Created("",employee);
            }
            return BadRequest("Employee save failed.");
        }
        [HttpPut]
        public ActionResult<Employee> Update(Employee employee) 
        {
           if(employee.employeeId==0)
            {
                return BadRequest("EmployeeId is missing");
            }
           
            bool isUpdate=_employeeManager.Update(employee);
            if(isUpdate)
            {
                return Ok(employee);
           }
            return BadRequest("Employee updated failed");
        }


        //public async Task<IActionResult> UpdateEmployee(int employeeId, Employee employee)
        //{

        //   if (employeeId != employee.employeeId)
        //    {
        //       // Check if the new employee code is already exists.
        //       var existingEmployee =await _dbContext.Employees.FirstOrDefaultAsync(e => e.employeeCode == employee.employeeCode);
        //        if (existingEmployee != null)
        //       {
        //            return BadRequest("Employee code already exists.");
        //        }
        //   }

        //   _dbContext.Employees.Update(employee);
        //   await _dbContext.SaveChangesAsync();

        //    return Ok();
        //}

        [HttpDelete("id")]
        public ActionResult<string>Delete(int id) 
        {
            var employee =_employeeManager.GetById(id);
            if(employee==null) 
            {
                return NotFound();
            }
            bool isDelete = _employeeManager.Delete(employee);
            if(isDelete)
            {
                return Ok("Employee has been deleted");
            
            }
            return BadRequest("Employee delete failed");
        
        }

        [HttpPut]
       
        public async Task<IActionResult> UpdateEmployee(int EmployeeId, string EmployeeName, string EmployeeCode)
        {
            // Check if the employee exists.
            Employee employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.employeeId == EmployeeId);
            if (employee is null)
            {
                return NotFound("Employee not found.");
            }

            // Check if the new employee code is already exists.
            Employee existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.employeeCode == EmployeeCode);
            if (existingEmployee is not null && existingEmployee.employeeId != EmployeeId)
            {
                return Conflict("Employee code already exists.");
            }

            // Update the employee.
            employee.employeeName = EmployeeName;
            employee.employeeCode = EmployeeCode;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                message = "Employee updated successfully."
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetThirdHighestSalary()
        {
            // Get the employees sorted by salary in descending order.
            var employees = await _dbContext.Employees
                .OrderByDescending(e => e.employeeSalary)
                .Take(3)
                .ToListAsync();

            // Return the third employee.
            if (employees.Count >= 3)
            {
                return Ok(employees[2]);
            }
            else
            {
                return NotFound("There are not enough employees.");
            }
        }
        [HttpGet]
        public IActionResult GetAllDesc()
        {
            var employees=_employeeManager.GetAll().OrderByDescending(c=>c.employeeSalary).ToList();
            return Ok(employees);
        }
        
      
       
    }
}

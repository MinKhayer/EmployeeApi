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
    public class EmployeeAttendanceController : ControllerBase
    {
        EmployeeDbContext _dbContext;
        IEmployeeAttendanceManager _employeeAttendanceManager;
        public EmployeeAttendanceController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
            _employeeAttendanceManager = new EmployeeAttendanceManager(dbContext);
        }
        [HttpGet]
        public ActionResult<List<EmployeeAttendance>> GetAll()
        {
            //var employees = _dbContext.Employees.ToList();
            var attendances = _employeeAttendanceManager.GetAll().ToList();
            return Ok(attendances);
        }
        [HttpGet]
        public ActionResult<EmployeeAttendance> GetById(int id)
        {
            var employeeAttendance = _employeeAttendanceManager.GetById(id);
            if (employeeAttendance == null)
            {
                return NotFound();
            }
            return Ok(employeeAttendance);
        }
        [HttpPost]
        public ActionResult<EmployeeAttendance> Add(EmployeeAttendance employeeAttendance)
        {
            bool isSaved = _employeeAttendanceManager.Add(employeeAttendance);
            //_dbContext.Employees.Add(employee);
            //bool isSaved=_dbContext.SaveChanges()>0;
            if (isSaved)
            {
                return Created("", employeeAttendance);
            }
            return BadRequest("Employee save failed.");
        }
        [HttpPut]
        public ActionResult<EmployeeAttendance> Update(EmployeeAttendance employeeAttendance)
        {
            if (employeeAttendance.attendanceId == 0)
            {
                return BadRequest("EmployeeId is missing");
            }

            bool isUpdate = _employeeAttendanceManager.Update(employeeAttendance);
            if (isUpdate)
            {
                return Ok(employeeAttendance);
            }
            return BadRequest("Employee updated failed");
        }
        

       

     
    }
}

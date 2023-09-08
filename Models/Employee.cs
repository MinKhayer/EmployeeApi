using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        public string employeeName { get; set; }
        [Required]
        public string employeeCode { get; set; }
        [Required]
        public int employeeSalary { get; set; }
        [Required]
        public int supervisorId { get; set; }
        public object Attendances { get; internal set; }
        public object AttendanceRecords { get; internal set; }
    }
}

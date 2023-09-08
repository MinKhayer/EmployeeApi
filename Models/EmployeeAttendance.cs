using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int attendanceId { get; set; }
        [Required]
        public int employeeId { get; set; }
        [Required]
        public DateTime attendanceDate { get; set; }
        [Required]
        public bool isPresent { get; set; }
        [Required]
        public bool isAbsent { get; set; }
        [Required]  
        public bool isOffday { get; set; }

    }
}

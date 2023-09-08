using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class Hierarchy
    {
        [Key]
        public int hierarchyId { get; set; }
        [Required]
        public int employeeId { get; set; }
        [Required]
        public int supervisorId { get; set; }
    }
}

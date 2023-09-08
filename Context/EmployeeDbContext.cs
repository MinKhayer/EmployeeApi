using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Context
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> Attendances { get; set; }
        public DbSet<Hierarchy> Hierarchys { get; set;}
        public object AttendanceRecords { get; internal set; }
    }
}

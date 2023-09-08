using EF.Core.Repository.Repository;
using EmployeeApi.Context;
using EmployeeApi.Interfaces.Repository;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class EmployeeAttendanceRepository : CommonRepository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {
        public EmployeeAttendanceRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}

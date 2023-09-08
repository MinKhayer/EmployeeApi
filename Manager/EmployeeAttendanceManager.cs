using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using EmployeeApi.Context;
using EmployeeApi.Interfaces.Manager;
using EmployeeApi.Models;
using EmployeeApi.Repository;

namespace EmployeeApi.Manager
{
    public class EmployeeAttendanceManager : CommonManager<EmployeeAttendance>, IEmployeeAttendanceManager
    {
        public EmployeeAttendanceManager(EmployeeDbContext _dbContext) : base(new EmployeeAttendanceRepository(_dbContext))
        {
        }

        public EmployeeAttendance GetById(int id)
        {
            return GetFirstOrDefault(x=> x.attendanceId == id);
        }
    }
}

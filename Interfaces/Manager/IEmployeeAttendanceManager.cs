using EF.Core.Repository.Interface.Manager;
using EmployeeApi.Models;

namespace EmployeeApi.Interfaces.Manager
{
    public interface IEmployeeAttendanceManager: ICommonManager<EmployeeAttendance>
    {
        EmployeeAttendance GetById(int id);
    }
}

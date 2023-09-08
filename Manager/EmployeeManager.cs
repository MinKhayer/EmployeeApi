using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using EmployeeApi.Context;
using EmployeeApi.Interfaces.Manager;
using EmployeeApi.Models;
using EmployeeApi.Repository;

namespace EmployeeApi.Manager
{
    public class EmployeeManager : CommonManager<Employee>, IEmployeeManager
    {
        public EmployeeManager(EmployeeDbContext _dbContext) : base(new EmployeeRepository(_dbContext))
        {
        }

        public Employee GetById(int id)
        {
            return GetFirstOrDefault(x => x.employeeId == id);
        }
    }
}

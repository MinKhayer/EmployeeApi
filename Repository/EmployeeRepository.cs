using EF.Core.Repository.Repository;
using EmployeeApi.Context;
using EmployeeApi.Interfaces.Repository;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDao.Model;
using TestDto;

namespace TestDao.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}

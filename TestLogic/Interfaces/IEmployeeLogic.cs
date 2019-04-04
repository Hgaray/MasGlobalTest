using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDto;

namespace TestLogic.Interfaces
{
    public interface IEmployeeLogic
    {
        Task<List<EmployeeSalary>> GetAll();

        Task<List<EmployeeSalary>> GetById(int Id);
    }
}

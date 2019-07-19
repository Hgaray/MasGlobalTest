using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDao.Model;
using TestDao.Repositories.Interfaces;
using TestDao.Models;
using System.Linq;
using AutoMapper;

namespace TestDao.Repositories
{
    public class EmployeeFromContextRepository : IEmployeeRepository
    {
        public Task<IEnumerable<Model.Employee>> GetAll()
        {
            try
            {
                using (var ctx = new TestContext())
                {
                    var empList = ctx.Employee.ToList();

                    var respuesta = (Mapper.Map<IEnumerable<Models.Employee>, IEnumerable<Model.Employee>>(empList));

                    return Task.FromResult(respuesta);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

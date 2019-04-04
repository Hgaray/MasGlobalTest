using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDao.Configurations;
using TestDao.Model;
using TestDao.Repositories.Interfaces;
using TestDto;
using TestHelpers;
using AutoMapper;
using System.Linq;

namespace TestDao.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {        

        public async Task<IEnumerable<Employee>> GetAll()
        {

            try
            {
                IEnumerable<Employee> respuesta;
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(ConstantValues.UrlEmployeesApi);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                respuesta = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);              
                return respuesta;
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
    }
}

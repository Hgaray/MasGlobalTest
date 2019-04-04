using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TestDao.Model;

namespace UnitTestProjectHgaray
{
    public class EmployeeRepositoryMock
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> respuesta;
            List<Employee> listMock = new List<Employee>();
            listMock.Add(new Employee() { Id = 1, Name = "Hgaray" });
            var jsonSerialiser = new JavaScriptSerializer();
            var json =  jsonSerialiser.Serialize(listMock);

            respuesta =  JsonConvert.DeserializeObject<IEnumerable<Employee>>(json);

            return  respuesta;
        }
    }
}

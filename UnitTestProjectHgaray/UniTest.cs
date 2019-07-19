using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDao.Model;
using TestDao.Repositories.Interfaces;
using TestDao.Repositories;
using System.Linq;
using TestLogic;
using TestDto;
using TestLogic.Interfaces;
using TestDao.Configurations;

namespace UnitTestProjectHgaray
{
    [TestClass]
    public class UniTest
    {

        IEmployeeRepository _IEmployeeRepository;
        MyMaps myMaps = new MyMaps();
        int flag = 0;






        [TestMethod]
        public async Task GetEmployeesTest()
        {

            MyMaps.Initialize();

            _IEmployeeRepository = new EmployeeRepository();

            EmployeeLogic obj = new EmployeeLogic(_IEmployeeRepository);
            var respuesta = obj.GetAll();

            Assert.IsTrue(respuesta.Result.Count() > 1);

            MyMaps.TearDown();
        }

        [TestMethod]
        public async Task GetEmployeesByIdTest()
        {
            MyMaps.Initialize();

            int expectedvalue = 1;
            _IEmployeeRepository = new EmployeeRepository();

            EmployeeLogic obj = new EmployeeLogic(_IEmployeeRepository);
            var respuesta = obj.GetById(1);

            Assert.AreEqual(expectedvalue,respuesta.Result.Count() );

            MyMaps.TearDown();
        }

        [TestMethod]
        public async Task CountResultTest()
        {
            List<Employee> pp = new List<Employee>();
            pp.Add(new Employee() { Id = 1 });
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(pp);
            var u = mockRepository.Object.GetAll();
            var json = u.Result;
            Assert.AreEqual(pp.Count(), json.Count());

        }


    }
}

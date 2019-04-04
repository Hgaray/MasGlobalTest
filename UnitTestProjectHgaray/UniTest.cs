using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDao.Model;
using TestDao.Repositories.Interfaces;
using System.Linq;

namespace UnitTestProjectHgaray
{
    [TestClass]
    public class UniTest
    {
        [TestMethod]
        public async Task CountResultTest()
        {
            List<Employee> pp = new List<Employee>();
            pp.Add(new Employee(){Id=1 });
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(pp);
            var u = mockRepository.Object.GetAll();
            var json = u.Result;
            Assert.AreEqual(pp.Count(), json.Count());
        }
    }
}

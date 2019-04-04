using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestPresentationWeb.Models;

namespace TestPresentationWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeView()
        {
            return View();
        }

        public JsonResult SearchEmployees(string Id)
        {

            try
            {
                string url = string.Empty;
                var httpClient = new HttpClient();
                var content = new HttpResponseMessage();


                if (string.IsNullOrEmpty(Id))
                {
                    url = "https://localhost:44315/api/employee/GetAllEmployees";
                    content = httpClient.GetAsync(url).Result;
                    var json = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content.Content.ReadAsStringAsync().Result);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    url += "https://localhost:44315/api/employee/GetAllEmployeeById/?Id=" + Convert.ToInt32(Id);
                    content = httpClient.GetAsync(url).Result;
                    var json = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content.Content.ReadAsStringAsync().Result);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
    }
}
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


        private string getAllEmployees = "GetAllEmployees";
        private string getEmployeesById = "GetAllEmployeeById/?Id=";


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

                url = System.Configuration.ConfigurationManager.AppSettings["ApiEmployee"].ToString();
                if (string.IsNullOrEmpty(Id))
                {
                    
                    url += getAllEmployees;
                    content = httpClient.GetAsync(url).Result;
                    var json = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content.Content.ReadAsStringAsync().Result);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    url += getEmployeesById + Convert.ToInt32(Id);
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
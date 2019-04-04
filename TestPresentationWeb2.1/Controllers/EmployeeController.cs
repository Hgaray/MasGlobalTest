using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;


namespace TestPresentationWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeView()
        {
            return View();
        }

        public ActionResult Prueba()
        {
            return View();
        }

        public JsonResult SearchEmployees(string Id)
        {

            try
            {
                var url = "https://localhost:44315/api/employee/GetAllEmployees";
                var httpClient = new HttpClient();
                var json = httpClient.GetAsync(url).Result;
                return Json(json);
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestLogic;
using TestLogic.Interfaces;

namespace TechnicalTest.MasGlobal.Hgaray.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeLogic _IEmployeeLogic;
        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _IEmployeeLogic = employeeLogic;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _IEmployeeLogic.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAllEmployeeById")]
        public async Task<IActionResult> GetAllEmployeeById(int Id)
        {
            try
            {
                return Ok(await _IEmployeeLogic.GetById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
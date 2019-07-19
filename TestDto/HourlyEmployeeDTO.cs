using System;
using System.Collections.Generic;
using System.Text;

namespace TestDto
{
    public class HourlyEmployeeDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == "HourlySalaryEmployee")
                {
                    AnnualSalary = 120 * HourlySalary * 12;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

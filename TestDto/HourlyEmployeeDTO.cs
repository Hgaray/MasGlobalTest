using System;
using System.Collections.Generic;
using System.Text;

namespace TestDto
{
    public class HourlyEmployeeDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            if (ContractTypeName == "HourlySalaryEmployee")
            {
                AnnualSalary = 120 * HourlySalary * 12;
            }
        }
    }
}

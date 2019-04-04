using System;
using System.Collections.Generic;
using System.Text;

namespace TestDto
{
    public class MonthlyEmployeeDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            if (ContractTypeName == "MonthlySalaryEmployee")
            {
                AnnualSalary = MonthlySalary * 12;
            }
        }
    }
}

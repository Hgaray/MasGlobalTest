using System;
using System.Collections.Generic;
using System.Text;

namespace TestDto
{
    public class MonthlyEmployeeDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == "MonthlySalaryEmployee")
                {
                    AnnualSalary = MonthlySalary * 12;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

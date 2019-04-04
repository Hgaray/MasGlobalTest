using System;
using System.Collections.Generic;
using System.Text;

namespace TestDto
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double AnnualSalary { get; set; }
    }
}

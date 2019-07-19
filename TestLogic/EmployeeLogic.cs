using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDto;
using TestDao;
using TestDao.Repositories.Interfaces;
using TestDao.Repositories;
using TestLogic.Interfaces;
using TestDao.Model;
using System.Linq;
using TestHelpers;
using AutoMapper;

namespace TestLogic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        private IEmployeeRepository _EmployeeLogic;
        public EmployeeLogic(IEmployeeRepository employeeLogic)
        {

            _EmployeeLogic = employeeLogic;
        }


        public async Task<List<EmployeeSalary>> GetAll()
        {

            try
            {
                List<EmployeeSalary> respuesta = new List<EmployeeSalary>();

                var result = await _EmployeeLogic.GetAll();

                var hourlyList = result.Where(x => x.ContractTypeName == ConstantValues.ContractHourly).ToList();
                var monthlyList = result.Where(x => x.ContractTypeName == ConstantValues.ContractMonthly).ToList();
                var employeeHourlyList = Mapper.Map<IEnumerable<Employee>, IEnumerable<HourlyEmployeeDTO>>(hourlyList).ToList();
                var employeeMonthlyList = Mapper.Map<IEnumerable<Employee>, IEnumerable<MonthlyEmployeeDTO>>(monthlyList).ToList();

                employeeHourlyList.ForEach(x => x.CalculateSalary());
                employeeMonthlyList.ForEach(x => x.CalculateSalary());

                respuesta.AddRange(Mapper.Map<IEnumerable<HourlyEmployeeDTO>, IEnumerable<EmployeeSalary>>(employeeHourlyList).ToList());
                respuesta.AddRange(Mapper.Map<IEnumerable<MonthlyEmployeeDTO>, IEnumerable<EmployeeSalary>>(employeeMonthlyList).ToList());

                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeSalary>> GetById(int Id)
        {
            try
            {
                List<EmployeeSalary> respuesta = new List<EmployeeSalary>();
                EmployeeSalary employeeSalary = new EmployeeSalary();
                var result = await _EmployeeLogic.GetAll();

                var employee = result.Where(x => x.Id == Id).FirstOrDefault();

                if (employee.ContractTypeName == ConstantValues.ContractHourly)
                {
                    var employeeHourly = Mapper.Map<Employee, HourlyEmployeeDTO>(employee);
                    employeeHourly.CalculateSalary();
                    employeeSalary = Mapper.Map<HourlyEmployeeDTO, EmployeeSalary>(employeeHourly);
                }
                else
                {
                    var employeeMonthly = Mapper.Map<Employee, MonthlyEmployeeDTO>(employee);
                    employeeMonthly.CalculateSalary();
                    employeeSalary = Mapper.Map<MonthlyEmployeeDTO, EmployeeSalary>(employeeMonthly);
                }

                respuesta.Add(employeeSalary);

                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

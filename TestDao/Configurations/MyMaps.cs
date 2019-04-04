using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TestDao.Model;
using TestDto;

namespace TestDao.Configurations
{
    public class MyMaps
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeDTO, Employee>();

                cfg.CreateMap<Employee, HourlyEmployeeDTO>();
                cfg.CreateMap<Employee, MonthlyEmployeeDTO>();

                cfg.CreateMap<HourlyEmployeeDTO, EmployeeSalary>();
                cfg.CreateMap<MonthlyEmployeeDTO, EmployeeSalary>();
            });
        }
    }
}

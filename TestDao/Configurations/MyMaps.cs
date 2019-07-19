using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TestDao.Model;
using TestDao.Models;
using TestDto;

namespace TestDao.Configurations
{
    public class MyMaps
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Model.Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeDTO, Model.Employee>();
                

                cfg.CreateMap<Model.Employee, HourlyEmployeeDTO>();
                cfg.CreateMap<Model.Employee, MonthlyEmployeeDTO>();

                cfg.CreateMap<HourlyEmployeeDTO, EmployeeSalary>();
                cfg.CreateMap<MonthlyEmployeeDTO, EmployeeSalary>();


                cfg.CreateMap<Models.Employee, Model.Employee>();
            });
        }
    }
}

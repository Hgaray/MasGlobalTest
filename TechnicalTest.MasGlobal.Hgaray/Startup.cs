using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestDao;
using TestDao.Configurations;
using TestDao.Repositories;
using TestDao.Repositories.Interfaces;
using TestLogic;
using TestLogic.Interfaces;

namespace TechnicalTest.MasGlobal.Hgaray
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient<IEmployeeLogic, EmployeeLogic>();

            services.AddSingleton(Configuration);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Hgaray MasGlobal Test",
                    Version = "v1",
                    Description = "Hgaray MasGlobal Test",
                    TermsOfService = "Test"
                });
            });

            MyMaps.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger().UseSwaggerUI(c => {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "My API V1");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

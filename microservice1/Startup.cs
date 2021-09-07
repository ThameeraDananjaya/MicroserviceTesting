using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace microservice1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment currentEnvironment { get; }

        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            currentEnvironment = env;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            var connStr=Configuration.GetConnectionString("DevConnection");
            
            
            // if (currentEnvironment.EnvironmentName=="DOCKER")
            //     connStr= Configuration.GetConnectionString("DockerConnection");
            // if (currentEnvironment.EnvironmentName=="Development")
            //     connStr= Configuration.GetConnectionString("DevConnection");

            services.AddDbContext<MS1Context>(options => {
                options.UseSqlServer(connStr);
            });

             //services.AddSingleton<IEmployeeData, MockEmployeeData>();  - For Mocking data
             services.AddScoped<IEmployeeData,SqlEmpData>();
             services.AddScoped<IPlatformData,SqlPlatformData>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "microservice1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "microservice1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ParkingPalAPI.Services;
using ParkingPalAPI.Formatters;
using Newtonsoft.Json;

namespace ParkingPalAPI
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
            services.AddOptions();
            DataAccessService s = new DataAccessService();
            Configuration.GetSection("DataAccessService").Bind(s);
            //var section = new StronglyTypedConfigSection();
            //var dataAccessService = JsonConvert.DeserializeObject<DataAccessService>(Configuration["DataAccessService"]);
            services.AddSingleton<DataAccessService>(s);
            //services.Configure<DataAccessService>(options => Configuration.GetSection("ParkingPalConfig:DataAccessService").Bind(options));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddMvc(o=> o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            //app.UseCorsMiddleware();
            app.UseMvc();
        }
    }
}

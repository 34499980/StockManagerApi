using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Class;
using Business.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository.Class;
using Repository.Class.Context;
using Repository.Interface;

namespace StockManagerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            
            services.AddDbContext<StockManagerContext>(op => op.UseSqlServer(Configuration["ConnectionString:StockManagerDB"]));
            var builder = new ContainerBuilder();
            services.AddCors(options => {
                options.AddDefaultPolicy(x => { x.WithOrigins("*"); });
            }) ;
           
            services.AddScoped<IUserRep, UserRep>();
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<ISucursalRep, SucuralRep>();
            services.AddScoped<ISucursalBL, SucursalBL>();
            services.AddScoped<IDispatchRep, DispatchRep>();
            services.AddScoped<IDispatchBL, DispatchBL>();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            //app.UseCors(builder => builder    
            //     .AllowAnyOrigin()
            //    .AllowAnyMethod()                
            //    .WithHeaders( "Content-Type"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

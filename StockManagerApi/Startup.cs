using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Business.AutoMapper;
using Business.Class;
using Business.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
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
using StockManagerApi.Extensions;

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
            MiddlewareConfigurations.Authentication(services, Configuration);
            services.AddControllers();
            services.AddMvc();



            //DataBase Configuration
            MiddlewareConfigurations.ConnectionConfiguration(services,Configuration);
            //AutoMapper
            MiddlewareConfigurations.AutoMapperConfiguration(services);
            //Declaracion de inyecciones
            MiddlewareConfigurations.DependecInjection(services);
            //Cors Configuration
            MiddlewareConfigurations.CorsConfiguration(services);
           

            var builder = new ContainerBuilder();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = (c) =>
                {
                    var exception = c.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exception.Error.GetType().Name
                    switch
                    {
                        "ArgumentException" => HttpStatusCode.NotFound,_
                        => HttpStatusCode.ServiceUnavailable
                    };
                    c.Response.StatusCode = (int)statusCode;
                    var content = Encoding.UTF8.GetBytes(exception.Error.Message);
                    c.Response.Body.WriteAsync(content, 0, content.Length);
                    return Task.CompletedTask;
                }
            });

            app.UseAuthentication();
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

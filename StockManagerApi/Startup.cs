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
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Repository.Class;
using Repository.Class.Context;
using Repository.Interface;
using StockManagerApi.Extensions;
using Microsoft.OpenApi.Models;


namespace StockManagerApi
{
    public class Startup
    {
        private const string SECRET_KEY = "asdwda1d8a4sd8w4das8d*w8d*asd@#";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
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
            AddSwagger(services);
            services.AddAuthentication(options =>
            {
               // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
                .AddJwtBearer("JwtBearer", jwtOptions =>
                {
                    jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        IssuerSigningKey = SIGNING_KEY,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "https://localhost:44362",
                        ValidAudience = "https://localhost:44362",
                        ValidateLifetime = true
                    };
                });

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
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"StockManagment",
                    Version = groupName,
                    Description = "StockManagment API",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockManagment API V1");
            });
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
          
            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            //app.UseCors(builder => builder    
            //     .AllowAnyOrigin()
            //    .AllowAnyMethod()                
            //    .WithHeaders( "Content-Type"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

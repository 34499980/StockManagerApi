using AutoMapper;
using Business.AutoMapper;
using Business.Class;
using Business.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagerApi.Extensions
{
    public static class MiddlewareConfigurations
    {
        public static void AutoMapperConfiguration(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
        }
        public static void CorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddDefaultPolicy(x => { x.WithOrigins("*"); });
            });
        }
        public static void DependecInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRep, UserRep>();
            services.AddScoped<IOfficeRep, OfficeRep>();
            services.AddScoped<IDispatchRep, DispatchRep>();
            services.AddScoped<IStockRep, StockRep>();
            services.AddScoped<IRuleRep, RuleRep>();
            services.AddScoped<IDataSourceRep, DataSourceRep>();

            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IOfficeBL, OfficeBL>();
            services.AddScoped<IDispatchBL, DispatchBL>();
            services.AddScoped<IStockBL, StockBL>();
            services.AddScoped<IRuleBL, RuleBL>();
            services.AddScoped<IDataSourceBL, DataSourceBL>();
        }
        public static void ConnectionConfiguration(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<StockManagerContext>(op => op.UseSqlServer(Configuration["ConnectionString:StockManagerDB"]));
        }
    }
}

using AutoMapper;
using Business.AutoMapper;
using Business.Class;
using Business.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            services.AddScoped<IHistoryRep, HistoryRep>();
            services.AddScoped<ISaleRep, SaleRep>();
            services.AddScoped<IDiscountRep, DiscountRep>();

            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IOfficeBL, OfficeBL>();
            services.AddScoped<IDispatchBL, DispatchBL>();
            services.AddScoped<IStockBL, StockBL>();
            services.AddScoped<IRuleBL, RuleBL>();
            services.AddScoped<IDataSourceBL, DataSourceBL>();
            services.AddScoped<IHistoryBL, HistoryBL>();
            services.AddScoped<ISaleBL, SaleBL>();
            services.AddScoped<IDiscountBL, DiscountBL>();
        }

        public static void Authentication(IServiceCollection services, IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }
        public static void ConnectionConfiguration(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<StockManagerContext>(op => op.UseSqlServer(Configuration["ConnectionString:StockManagerDB"]));
        }

    }
}

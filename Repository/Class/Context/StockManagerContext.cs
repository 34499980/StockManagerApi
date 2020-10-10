using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace Repository.Class.Context
{
    public class StockManagerContext: DbContext
    {
        public StockManagerContext(DbContextOptions<StockManagerContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> USERS { get; set; }       

        public DbSet<Dispatch> DISPATCH { get; set; }
        public DbSet<Rules> RULES { get; set; }
        public DbSet<Sale> SALE { get; set; }       
        public DbSet<Rules_Permission> RULES_PERMISSION { get; set; }
        public DbSet<Sucursal> SUCURSAL { get; set; }
        public DbSet<Dispatch_State> DISPATCH_STATE { get; set; }
        public DbSet<Dispatch_Stock> DISPATCH_STOCK { get; set; }
        public DbSet<Stock> STOCK { get; set; }
        public DbSet<Stock_State> STOCK_STATE { get; set; }
        public DbSet<Stock_Sucursal> STOCK_SUCURSAL { get; set; }
        

        //public IEnumerable<TEntity> ExecuteStoredProcedure<TEntity>(string storedProcedure, params object[] parameters) where TEntity : class
        //{
        //    //bool first = true;
        //    //var sqlQueryBuilder = new StringBuilder();
        //    //sqlQueryBuilder.AppendFormat("EXEC {0}", storedProcedure);
        //    //try
        //    //{
        //    //    if (parameters != null && parameters.Any())
        //    //    {

        //    //        foreach (var param in parameters.OfType<SqlParameter>())
        //    //        {
        //    //            if (first)
        //    //            {
        //    //                sqlQueryBuilder.AppendFormat(" {0} = {1} ", param.ParameterName, param.SqlValue);
        //    //                first = false;
        //    //            }
        //    //            else
        //    //            {
        //    //                sqlQueryBuilder.AppendFormat(", {0} =  {1}", param.ParameterName, param.SqlValue);
        //    //            }


        //    //        }
        //    //    }
        //        //return Database.SqlQuery<TEntity>(sqlQueryBuilder.ToString(), parameters);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}

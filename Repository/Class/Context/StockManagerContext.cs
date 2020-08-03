using DTO.Class;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<UserDto> USERS { get; set; }
        
        public DbSet<DispatchDto> DISPATCH { get; set; }
        public DbSet<RulesDto> RULES { get; set; }
        public DbSet<SaleDto> SALE { get; set; }       
        public DbSet<Rules_PermissionDto> RULES_PERMISSION { get; set; }
        public DbSet<SucursalDto> SUCURSAL { get; set; }
        public DbSet<Dispatch_StateDto> DISPATCH_STATE { get; set; }
        public DbSet<Dispatch_StockDto> DISPATCH_STOCK { get; set; }
        public DbSet<StockDto> STOCK { get; set; }
        public IEnumerable<TEntity> ExecuteStoredProcedure<TEntity>(string storedProcedure, params object[] parameters) where TEntity : class
        {
            bool first = true;
            var sqlQueryBuilder = new StringBuilder();
            sqlQueryBuilder.AppendFormat("EXEC {0}", storedProcedure);
            try
            {
                if (parameters != null && parameters.Any())
                {

                    foreach (var param in parameters.OfType<SqlParameter>())
                    {
                        if (first)
                        {
                            sqlQueryBuilder.AppendFormat(" {0} = {1} ", param.ParameterName, param.SqlValue);
                            first = false;
                        }
                        else
                        {
                            sqlQueryBuilder.AppendFormat(", {0} =  {1}", param.ParameterName, param.SqlValue);
                        }


                    }
                }
                // return Database.SqlQuery<TEntity>(sqlQueryBuilder.ToString(), parameters);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

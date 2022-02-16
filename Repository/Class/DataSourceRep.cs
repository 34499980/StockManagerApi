using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class.Context
{
    public class DataSourceRep : IDataSourceRep
    {
         private readonly StockManagerContext _context;
        public DataSourceRep(StockManagerContext context)
        {
            this._context = context;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                return this._context.COUNTRY.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Dispatch_State> GetAllDispatchState()
        {
            try
            {
                return this._context.DISPATCH_STATE.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Stock_State> GetAllStockState()
        {
            try
            {
                return this._context.STOCK_STATE.ToList();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Roles> GetAllRoles()
        {
            try
            {
                return this._context.ROLES.ToList();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Actions> GetActions()
        {
            try
            {
                return this._context.ACTIONS.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Sale_State> GetSaleStates()
        {
            try
            {
                return this._context.SALE_SATETE.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

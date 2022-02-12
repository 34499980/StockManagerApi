using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Class
{
    public class SaleRep : ISaleRep
    {
        private readonly StockManagerContext _context;
        public SaleRep(StockManagerContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Graba una nueva venta y devuelve su id
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public Sale save(Sale sale)
        {
            try
            {
                this._context.SALE.Add(sale);
                this._context.SaveChanges();
                return sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

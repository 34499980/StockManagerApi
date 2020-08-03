using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    public class StockRep : IStockRep
    {
        private readonly StockManagerContext _context;
        public StockRep(StockManagerContext context)
        {
            this._context = context;
        }
        public StockDto GetStockById(long id)
        {
            try
            {
                return this._context.STOCK.Where(x => x.ID == id).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StockDto> GetAllStock()
        {
            try
            {
                return this._context.STOCK.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

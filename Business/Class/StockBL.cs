using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Class
{
    public class StockBL : IStockBL
    {
        private readonly IStockRep _stockRep;
        public StockBL(IStockRep stockRep)
        {
            this._stockRep = stockRep;
        }
        public StockDto GetStockById(int id)
        {
            try
            {
                var stock = this._stockRep.GetAllStock();
                return this._stockRep.GetStockById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StockDto> GetAllStock()
        {
            try
            {
                return this._stockRep.GetAllStock();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

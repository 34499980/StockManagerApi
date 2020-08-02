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
                return this._stockRep.GetStockById(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

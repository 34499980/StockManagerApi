using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IStockBL
    {
        StockDto GetStockByCode(string code);
        IEnumerable<StockDto> GetAllStock();
        void SaveStock(StockDto stock, string userInput);
        void UpdateStock(StockDto stock,string userInput);
    }
}

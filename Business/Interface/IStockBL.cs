using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IStockBL
    {
        IEnumerable<StockDto> GetStockByCode(string code);
        IEnumerable<StockDto> GetAllStock();
        void SaveStock(StockDto stock, string userInput);
        void UpdateStock(StockDto stock,string userInput);
        IEnumerable<StockDto> GetStockByParams(string param);
        IEnumerable<Stock_StateDto> GetStates();
        IEnumerable<StockDto> GetStockFilter(StockFilterDto dto);
    }
}

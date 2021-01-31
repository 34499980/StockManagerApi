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
        StockDto GetStockById(int id);
        void SaveStock(StockDto stock);
        void UpdateStock(StockDto stock);
        IEnumerable<StockDto> GetStockByParams(string param);
        IEnumerable<Stock_StateDto> GetStates();
        IEnumerable<Stock_OfficeDto> GetStockFilter(StockFilterDto dto);
        void delete(int id);
    }
}

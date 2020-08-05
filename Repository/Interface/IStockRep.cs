using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IStockRep
    {
        StockDto GetStockById(long id);
        IEnumerable<StockDto> GetAllStock();
        void SaveStock(StockDto stock);
        void UpdateStock(StockDto stock);
        void UpdateQR(StockDto stock);
        long GetQR(StockDto stock);
        IEnumerable<Stock_StateDto> GetAllStates();
        void saveStockBySucursal(StockDto stock);
        IEnumerable<Stock_SucursalDto> GetStockBySucursal(StockDto stock);
    }
}

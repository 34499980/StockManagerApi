using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IStockRep
    {
        IEnumerable<StockDto> GetStockByCode(string qr);
        IEnumerable<StockDto> GetAllStock();
        void SaveStock(StockDto stock);
        void UpdateStock(StockDto stock);       
        IEnumerable<Stock_StateDto> GetAllStates();
        void saveStockBySucursal(StockDto stock);
        IEnumerable<StockDto> GetStockByParams(string param, string name);
        void UpdateStockBySucursal(Stock_SucursalDto stock);
        StockDto GetStockById(long id);
        ICollection<Stock_SucursalDto> GetStockSucursalByIdStock(StockDto stock);
        Stock_SucursalDto GetStock_Sucursal(long idStock, int idSucursal);
    }
}

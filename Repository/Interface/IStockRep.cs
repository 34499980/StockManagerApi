using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IStockRep
    {
        IEnumerable<Stock> GetStockByCode(string qr);
        IEnumerable<Stock> GetAllStock();
        void SaveStock(Stock stock);
        void UpdateStock(Stock stock);       
        IEnumerable<Stock_State> GetAllStates();
        void saveStockBySucursal(Stock stock);
        IEnumerable<Stock> GetStockByParams(string param, string name);
        void UpdateStockBySucursal(Stock_Sucursal stock);
        Stock GetStockById(long id);
        ICollection<Stock_Sucursal> GetStockSucursalByIdStock(Stock stock);
        Stock_Sucursal GetStock_Sucursal(long idStock, int idSucursal);
    }
}

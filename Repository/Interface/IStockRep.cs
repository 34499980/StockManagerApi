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
        void saveStockByOffice(Stock stock);
        IEnumerable<Stock> GetStockByParams(string param, string name);
        void UpdateStockByOffice(Stock_Office stock);
        Stock GetStockById(long id);
        ICollection<Stock_Office> GetStockOfficeByIdStock(Stock stock);
        Stock_Office GetStock_Office(long idStock, int idSucursal);
    }
}

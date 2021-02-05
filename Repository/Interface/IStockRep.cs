using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IStockRep
    {
        Stock GetStockByCode(string qr);
        IEnumerable<Stock> GetAllStock();
        long SaveStock(Stock stock);
        void UpdateStock(Stock stock);       
        IEnumerable<Stock_State> GetAllStates();      
        IEnumerable<Stock> GetStockByParams(string param, string name);
        void UpdateStockByOffice(ICollection<Stock_Office> stock);
        Stock GetStockById(long id);
        ICollection<Stock_Office> GetStockOfficeByIdStock(Stock stock);
        Stock_Office GetStock_Office(long idStock, int idSucursal);
        IEnumerable<Stock_Office> GetOfficeFilter(StockFilterDto dto);
        void delete(int id);
    }
}

using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDispatchRep
    {
        Dispatch saveDispatch(Dispatch dispatch);      
        IEnumerable<Dispatch> GetAllDispatchesByOffice(int idSucursal);
        Dispatch GetDispatchById(int id);
        ICollection<Dispatch_Stock> GetStockIdByDispatch(int id);
        Dispatch GetDispatchByOffice(Dispatch dispatch);
        void UpdateDispatch(Dispatch dispatch);
        ICollection<Stock> GetStockByIdDispatch(int id);
        Task<IEnumerable<Dispatch>> GetDispatchFilter(DispatchFilterDto dto, int idOrigin);
        void removeDispatch(Dispatch_Stock dispatch_stock);
        void addDispatch_stock(Dispatch_Stock dispatch_stock);
        void UpdateDispatchStock(IEnumerable<Dispatch_Stock> stock);
    }
}

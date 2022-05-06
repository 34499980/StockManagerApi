using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IStockBL
    {
        StockDto GetStockByCode(string code);
        IEnumerable<StockDto> GetAllStock();
        StockDto GetStockById(int id);
        void SaveStock(StockDto stock);
        Task UpdateStock(StockDto stock);
        IEnumerable<StockDto> GetStockByParams(string param);
        IEnumerable<Stock_StateDto> GetStates();
        Task<ResultDto<Stock_OfficeDto>> GetStockFilter(StockFilterDto dto);
        void delete(int id);
    }
}

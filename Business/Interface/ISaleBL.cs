using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISaleBL
    {
        Task save(SaleDto dto);
        Task<ResultDto<SaleDto>> GetSalesByFilters(SaleFilterDto dto);
        Task<SaleDto> GetStockBySaleId(long id);
        Task ReturnAllSale(long idSale);
        Task<SaleDto> GetSaleById(long idSale);
        Task GenerateChanges(CalculateChangesDto dto);
    }
}

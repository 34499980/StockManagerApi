using DTO.Class;
using Repository.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ISaleRep
    {
        Task<Sale> save(Sale sale);
        Task<Result<Sale>> GetSalesByFilters(SaleFilterDto dto);
    }
}

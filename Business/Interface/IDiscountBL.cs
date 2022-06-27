using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDiscountBL
    {
        Task<DiscountDto> saveDiscount(DiscountPostDto discount);
        Task<IEnumerable<DiscountDto>> GetAllDiscountByOffice();
        Task<DiscountDto> GetDiscountById(int id);

        Task UpdateDiscount(DiscountDto discount);

        Task<ResultDto<DiscountDto>> GetDiscountFilter(DiscountFilterDto dto);
        Task removeDiscount(int IdDiscount);
        Task DisabledDiscount();
    }
}

using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class DiscountBL: IDiscountBL
    {
        private readonly IDiscountRep _discountRep;
        public DiscountBL(IDiscountRep discountRep)
        {
            this._discountRep = discountRep;
        }
        public async Task<IEnumerable<DiscountDto>> GetAllDiscountByOffice(int idOffice)
        {
            throw new NotImplementedException();
        }

        public async Task<DiscountDto> GetDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<DiscountDto>> GetDiscountFilter(DiscountFilterDto dto, int idOrigin)
        {
            throw new NotImplementedException();
        }

        public async Task removeDiscount(int IdDiscount)
        {
            throw new NotImplementedException();
        }

        public async Task<DiscountDto> saveDiscount(DiscountDto discount)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDiscount(DiscountDto discount)
        {
            throw new NotImplementedException();
        }
    }
}

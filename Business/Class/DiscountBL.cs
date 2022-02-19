using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class DiscountBL: IDiscountBL
    {
        private readonly IDiscountRep _discountRep;
        private readonly IMapper _mapper;
        public DiscountBL(IDiscountRep discountRep, IMapper mapper)
        {
            this._mapper = mapper;
            this._discountRep = discountRep;
        }
        public async Task<IEnumerable<DiscountDto>> GetAllDiscountByOffice()
        {
            try
            {
               var result = await _discountRep.GetAllDiscountByOffice(ContextProvider.OfficeId);
                return _mapper.Map<IEnumerable<DiscountDto>>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiscountDto> GetDiscountById(int id)
        {
            try
            {
                var result = await _discountRep.GetDiscountById(id);
                return _mapper.Map<DiscountDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultDto<DiscountDto>> GetDiscountFilter(DiscountFilterDto dto)
        {
            try
            {
                var result = await _discountRep.GetDiscountFilter(dto);
                return _mapper.Map<ResultDto<DiscountDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task removeDiscount(int IdDiscount)
        {
            try
            {
                await _discountRep.removeDiscount(IdDiscount);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiscountDto> saveDiscount(DiscountDto discount)
        {
            try
            {
                var entity = _mapper.Map<Discount>(discount);
                var result = await _discountRep.saveDiscount(entity);
               return _mapper.Map<DiscountDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateDiscount(DiscountDto discount)
        {
            var entity = _mapper.Map<Discount>(discount);
            await _discountRep.UpdateDiscount(entity);
        }
    }
}

using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class DiscountBL : IDiscountBL
    {
        private readonly IDiscountRep _discountRep;
        private readonly IOfficeRep _officeRep;
        private readonly IMapper _mapper;
        public DiscountBL(IDiscountRep discountRep, IMapper mapper, IOfficeRep officeRep)
        {
            this._mapper = mapper;
            this._discountRep = discountRep;
            this._officeRep = officeRep;
        }
        public async Task<IEnumerable<DiscountDto>> GetAllDiscountByOffice()
        {
            try
            {
                var result = await _discountRep.GetAllDiscountByOffice(ContextProvider.OfficeId);
                return _mapper.Map<IEnumerable<DiscountDto>>(result);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiscountDto> saveDiscount(DiscountPostDto dto)
        {
            try
            {
                List<Discount_Office> discountOfficeList = new List<Discount_Office>();
                List<Discount_PaymentType> paymentType = new List<Discount_PaymentType>();
                Discount entity = new Discount()
                {
                    ID = dto.ID,
                    DateFrom = dto.DateFrom,
                    DateTo = dto.DateTo,
                    IdStock = dto.IdStock,
                    Percent = dto.Percent,
                    IdUser = ContextProvider.UserId,

                };
                if (dto.Offices.Length == 0)
                {
                    dto.Offices = (int[])_officeRep.GetOfficesByCountry(ContextProvider.SelectedCountry).Select(x => x.ID);
                }
                foreach (var item in dto.Offices)
                {
                    Discount_Office entityDiscountOffices = new Discount_Office()
                    {
                        IdOffice = item
                    };
                    discountOfficeList.Add(entityDiscountOffices);
                }
                foreach (var item in dto.PaymentType)
                {
                    Discount_PaymentType entityPaymentType = new Discount_PaymentType()
                    {
                        IdPaymentType = item
                    };
                paymentType.Add(entityPaymentType);
                }
                entity.PaymentTypeList = paymentType;
               
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

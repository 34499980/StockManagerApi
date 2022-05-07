using AutoMapper;
using Business.Interface;
using ConstantControl;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConstantControl.Constants;

namespace Business.Class
{
    public class DiscountBL : IDiscountBL
    {
        private readonly IDiscountRep _discountRep;
        private readonly IOfficeRep _officeRep;
        private readonly IMapper _mapper;
        private readonly IHistoryRep _historyRep;
        public DiscountBL(IDiscountRep discountRep, IMapper mapper, IOfficeRep officeRep, IHistoryRep historyRep)
        {
            this._mapper = mapper;
            this._discountRep = discountRep;
            this._officeRep = officeRep;
            this._historyRep = historyRep;
        }
        public async Task<IEnumerable<DiscountDto>> GetAllDiscountByOffice()
        {
            try
            {

                var result = await _discountRep.GetAllDiscountByOffice(ContextProvider.OfficeId, DateTime.Now);
                foreach (var item in result)
                {
                    item.PaymentTypeList = await this._discountRep.GetPaymentTypeByDiscount(item.ID);
                }
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
             //   var dtoResultList = _mapper.Map<IEnumerable<DiscountDto>>(result.data);
                List<DiscountDto> discountDtoList = new List<DiscountDto>();
                List<Office> officeList = null;
                List<PaymentType> paymentTypeList = null;
                var discountList = result.data;                
                foreach (var discount in discountList)
                {
                    officeList = new List<Office>();
                    paymentTypeList = new List<PaymentType>();
                    foreach (Discount_Office item in discount.Discount_Office)
                    {
                        officeList.Add(await _officeRep.GetOfficeById(item.IdOffice));
                    }
                    foreach (Discount_PaymentType item in discount.PaymentTypeList)
                    {
                        paymentTypeList.Add(await _discountRep.GetPaymentTypeById(item.IdPaymentType));
                    }
                    var dtoReturn = _mapper.Map<DiscountDto>(discount);
                    dtoReturn.Offices = _mapper.Map<IEnumerable<OfficeDto>>(officeList);
                    dtoReturn.PaymentType = _mapper.Map<IEnumerable<ItemDto>>(paymentTypeList);
                    discountDtoList.Add(dtoReturn);


                }
                var dataTodReturn = _mapper.Map<ResultDto<DiscountDto>>(result);
                dataTodReturn.data = discountDtoList;




              //  var dtoResult = _mapper.Map<DiscountDto>(discount);
               // dtoResult.PaymentType = _mapper.Map<ICollection<PaymentTypeDto>>(paymentTypeList);
               // dtoResult.Offices = _mapper.Map<ICollection<OfficeDto>>(officeList);
               // result.data = _mapper.Map<Discount>(dtoResult);
                return dataTodReturn;
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
                this._historyRep.AddHistory((int)Constants.Actions.Discount, Constants.HistoryDiscountDisabled, IdDiscount.ToString(), ContextProvider.OfficeId, ContextProvider.UserId);

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
                bool flag = false;
                List<Discount_Office> discountOfficeList = new List<Discount_Office>();
                List<Discount_PaymentType> paymentType = new List<Discount_PaymentType>();

                var discountExists = await _discountRep.GetDiscountsByDates(dto.DateFrom, dto.DateTo, dto.IdStock);
                if (discountExists != null)
                {
                    int i = 0;
                    while(i <= dto.officesIds.Count() && !flag)
                    {
                       if(discountExists.Discount_Office.Where(z => z.IdOffice == dto.officesIds.ElementAt(i)).Any())
                        {
                            flag = true;
                        }
                    }                   
                }
                if (dto.Override)
                {
                    discountExists.State = Convert.ToBoolean(Discount_State.Deshabilitado);
                    await _discountRep.UpdateDiscount(discountExists);
                    this._historyRep.AddHistory((int)Constants.Actions.Discount, Constants.HistoryDiscountDisabled, discountExists.ID.ToString(), ContextProvider.OfficeId, ContextProvider.UserId);

                    flag = false;
                    dto.Override = false;
                }
                if (!flag && !dto.Override)
                {
                    Discount entity = new Discount()
                    {
                        DateFrom = dto.DateFrom,
                        DateTo = dto.DateTo,
                        IdStock = dto.IdStock != null ? dto.IdStock : null,
                        Percent = dto.Percent,
                        IdUser = ContextProvider.UserId

                    };
                    if (dto.officesIds.Length == 0)
                    {
                        dto.officesIds = (int[])_officeRep.GetOfficesByCountry(ContextProvider.SelectedCountry).Select(x => x.ID);
                    }
                    foreach (var item in dto.officesIds)
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
                    entity.Discount_Office = discountOfficeList;
                    var result = await _discountRep.saveDiscount(entity);
                    this._historyRep.AddHistory((int)Constants.Actions.Discount, Constants.HistoryDiscountCreate, result.ID.ToString(), ContextProvider.OfficeId, ContextProvider.UserId);

                    return _mapper.Map<DiscountDto>(result);
                }
                else
                {
                    throw new Business.Exceptions.BussinessException(Constants.ErrDiscountExistsDates, 500);
                }
               
               
               
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
            this._historyRep.AddHistory((int)Constants.Actions.Discount, Constants.HistoryDiscountUpdated, discount.ID.ToString(), ContextProvider.OfficeId, ContextProvider.UserId);

        }
    }
}

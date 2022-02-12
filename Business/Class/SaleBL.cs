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

namespace Business.Class
{
    public class SaleBL: ISaleBL
    {
        private readonly ISaleRep _saleRep;
        private readonly IUserRep _userhRep;
        private readonly IOfficeRep _officeRep;
        private readonly IStockRep _stockRep;
        private readonly IHistoryRep _historyRep;
        private readonly IMapper _mapper;
        public SaleBL(ISaleRep saleRep, IUserRep userRep, IOfficeRep officeRep, IStockRep stockRep, IMapper mapper, IHistoryRep historyRep)
        {
            this._saleRep = saleRep;
            this._userhRep = userRep;
            this._officeRep = officeRep;
            this._stockRep = stockRep;
            this._historyRep = historyRep;
            this._mapper = mapper;
        }

        public SaleDto save(SaleDto dto)
        {
            try
            {
                decimal total = 0;
                Stock stock = null;
                List<Sale_Stock> saleStockList = new List<Sale_Stock>();
                foreach (var item in dto.Stock)
                {
                    decimal subTotal = 0;
                    stock = _stockRep.GetStockById(item.ID);
                    var stock_office = stock.Stock_Office.Where(x => x.IdStock == item.ID && x.IdOffice == ContextProvider.OfficeId).FirstOrDefault();
                    stock_office.Unity -= item.Unity;
                    subTotal = item.Unity * stock_office.Price;
                    total += subTotal;
                    saleStockList.Add(new Sale_Stock() { IdStock = item.ID, Unity = item.Unity });
                    _stockRep.UpdateStock(stock);

                }
                Sale entity = new Sale()
                {
                    Sale_stock = saleStockList,
                    Amount = total,
                    IdState = (int)Constants.Sale_State.Finalizado,
                    DateProces = DateTime.Now,
                    IdOffice = ContextProvider.OfficeId,
                    IdUser = ContextProvider.UserId                               
                };

                _saleRep.save(entity);
              
                this._historyRep.AddHistory((int)Constants.Actions.Sale, Constants.HistorySaleCreate, entity.ID.ToString(), ContextProvider.OfficeId, ContextProvider.UserId);
                return _mapper.Map<SaleDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstantControl;
using System.Text;
using AutoMapper;
using Repository.Entities;
using StockManagerApi.Extensions;
using System.Threading.Tasks;

namespace Business.Class
{
    public class DispatchBL: IDispatchBL
    {
        private readonly IDispatchRep _dispatchRep;
        private readonly IUserRep _userhRep;
        private readonly IOfficeRep _officeRep;
        private readonly IStockRep _stockRep;
        private readonly IMapper _mapper;
        public DispatchBL(IDispatchRep dispatchRep, IUserRep userRep, IOfficeRep officeRep, IStockRep stockRep, IMapper mapper)
        {
            this._dispatchRep = dispatchRep;
            this._userhRep = userRep;
            this._officeRep = officeRep;
            this._stockRep = stockRep;
            this._mapper = mapper;
        }
        /// <summary>
        /// Guarda despacho nuevo
        /// </summary>
        /// <param name="dispatch"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DispatchDto saveDispatch(DispatchDto dispatch)
        {
            try
            {
                if (dispatch.IdOrigin == dispatch.IdDestiny) throw new Business.Exceptions.BussinessException(Constants.ErrSameDestinationAndOrigin);
                
                var dispatchInput = _mapper.Map<Dispatch>(dispatch);
                dynamic result = this._dispatchRep.GetDispatchByOffice(dispatchInput);
                DispatchDto dispatchOut = _mapper.Map<DispatchDto>(result);
                if (result == null)
                {
                    dispatchInput.IdUserOrigin = ContextProvider.UserId;
                    dispatchInput.DateCreate = DateTime.Now;
                    dispatchInput.IdState =  (int)Constants.Dispatch_State.Creado;
                    dispatchInput.Unity = 0;
                    dispatchOut = _mapper.Map<DispatchDto>(this._dispatchRep.saveDispatch(dispatchInput));

                }
                else
                {
                    dispatchOut.Stock = new List<StockDto>();
                    foreach (var item in dispatchOut.Dispatch_stock)
                    {
                        var stock = _mapper.Map<StockDto>(this._stockRep.GetStockById(item.IdStock));
                        stock.Count = item.Unity;
                        stock.Unity = stock.Stock_Office.Where(x => x.IdOffice == dispatch.IdOrigin).FirstOrDefault().Unity;

                        dispatchOut.Stock.Add(stock);
                    }
                }

                return dispatchOut;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }       
        /// <summary>
        /// Devuelve todos los despachos
        /// </summary>
        /// <returns></returns>

        public IEnumerable<DispatchDto> GetAllDispatchesByOffice()
        {
            try
            {
                var result = this._dispatchRep.GetAllDispatchesByOffice(ContextProvider.OfficeId);
                return _mapper.Map<IEnumerable<DispatchDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca despacho por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public DispatchDto GetDispatchById(int id)
        {
            try
            {                          
                Dispatch dispatch =  this._dispatchRep.GetDispatchById(id);
                var dispatchOut = _mapper.Map<DispatchDto>(dispatch);
                dispatchOut.Stock = new List<StockDto>();
                if(dispatchOut.IdState == (int)Constants.Dispatch_State.Creado)
                {
                    foreach (var item in dispatchOut.Dispatch_stock)
                    {
                        var result = _mapper.Map<StockDto>(this._stockRep.GetStockById(item.IdStock));
                        result.Count = item.Unity;
                        result.Unity = result.Stock_Office.Where(x => x.IdOffice == dispatch.IdOrigin).FirstOrDefault().Unity;

                        dispatchOut.Stock.Add(result);
                    }
                } else
                {
                    foreach (var item in dispatchOut.Dispatch_stock)
                    {
                        var result = _mapper.Map<StockDto>(this._stockRep.GetStockById(item.IdStock));
                        result.Unity = item.Unity;
                        result.Count = item.UnityRead;

                        dispatchOut.Stock.Add(result);
                    }
                }
               
               
                

               
                return dispatchOut;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDispatch(DispatchDto dispatch)
        {
            int cantItems = 0;
            try
            {
                Dispatch dispatchDB = null;
                dispatchDB = this._dispatchRep.GetDispatchById(dispatch.ID);
                var exist = dispatchDB;
                if(dispatchDB == null)
                {
                   dispatchDB = this._mapper.Map<Dispatch>(dispatch);
                } else
                {
                    if (dispatch.Dispatch_stock.Any())
                    {
                        dispatchDB.Dispatch_stock = this._mapper.Map<ICollection<Dispatch_Stock>>(dispatch.Dispatch_stock);
                    }                   
                }              
                foreach (var item in dispatchDB.Dispatch_stock)
                {
                    cantItems += item.Unity;
                    if (item.Unity == 0)
                    {
                        this._dispatchRep.removeDispatch(item);
                    }
                }
                switch (dispatch.IdState)
                {
                    case (int)Constants.Dispatch_State.Creado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Creado;
                        dispatchDB.Unity = cantItems;
                        break;
                    case (int)Constants.Dispatch_State.Despachado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Despachado;
                        if (dispatchDB.DateDispatched == null)
                            dispatchDB.DateDispatched = DateTime.Now;
                        List<Stock_Office> stockList = new List<Stock_Office>();
                        foreach (var item in dispatchDB.Dispatch_stock)
                        {
                         var stock_office =  this._stockRep.GetStock_Office(item.IdStock, dispatchDB.IdOrigin);
                             stock_office.Unity -= item.Unity;
                            if (stock_office.Unity < -1) throw new Business.Exceptions.BussinessException(Constants.ErrStockHasCHange);
                            stockList.Add(stock_office);
                            

                        }
                        this._stockRep.UpdateStockByOffice(stockList);
                        break;
                    case (int)Constants.Dispatch_State.Recibido:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Recibido;
                        if (dispatchDB.DateReceived == null)
                        {
                            dispatchDB.DateReceived = DateTime.Now;
                            dispatchDB.IdUserDestiny = ContextProvider.UserId;
                        }
                        else
                        {
                            foreach (var item in dispatch.Stock)
                            {
                                dispatchDB.Dispatch_stock.Where(x => x.IdStock == item.ID).FirstOrDefault().UnityRead = item.Count;

                            }
                           
                        }
                      

                        break;
                    case (int)Constants.Dispatch_State.Finalizado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Finalizado;
                        List<Stock_Office> listStock = new List<Stock_Office>();

                        foreach (var item in dispatch.Stock)
                        {
                            dispatchDB.Dispatch_stock.Where(x => x.IdStock == item.ID).FirstOrDefault().UnityRead = item.Count;
                            var stock_office = this._stockRep.GetStock_Office(item.ID, ContextProvider.OfficeId);
                            stock_office.Unity = item.Unity;

                        }
                        if (dispatchDB.Dispatch_stock.Any(x => x.Unity != x.UnityRead)) 
                            throw new Business.Exceptions.BussinessException("errCheckDsipatchItems");  
                       
                        this._stockRep.UpdateStockByOffice(listStock);

                        break;
                    case (int)Constants.Dispatch_State.Incompleto:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Incompleto;
                        break;
                  
                }
                if (exist == null)
                {
                    this._dispatchRep.saveDispatch(dispatchDB);
                }
                else
                {
                    this._dispatchRep.UpdateDispatch(dispatchDB);
                }

                
               /* var dispatchInput = _mapper.Map<Dispatch>(dispatch);
                int countBult = 0;
                Dispatch_Stock dispatch_stock;
             
                List<Dispatch_Stock> listDispatch_Stock = new List<Dispatch_Stock>();
                if (dispatchInput.Stock != null && dispatchInput.IdState == (int)Constants.Dispatch_State.Creado 
                    || dispatchInput.IdState == (int)Constants.Dispatch_State.Despachado && dispatchInput.DateDispatched == null)
                {
                    foreach (var item in dispatchInput.Stock)
                    {
                        dispatch_stock = new Dispatch_Stock();
                        dispatch_stock.IdDispatch = dispatchInput.ID;
                        dispatch_stock.IdStock = this._stockRep.GetStockByCode(item.QR).FirstOrDefault().ID;
                        dispatch_stock.Unity = item.Unity;
                        countBult += item.Unity;
                    
                        if (dispatchInput.IdState == (int)Constants.Dispatch_State.Creado
                            || dispatchInput.IdState == (int)Constants.Dispatch_State.Despachado && dispatchInput.DateDispatched == null)
                        {
                          //  Stock_Office stock_officeDB = this._stockRep.GetStock_Office(dispatch_stock.IdStock, dispatchInput.Origin);
                        //    stock_officeDB.Unity = stock_officeDB.Unity - item.Unity;
                         
                         //   this._stockRep.UpdateStockByOffice(stock_officeDB);

                        }
                        else
                        {

                        }
                        listDispatch_Stock.Add(dispatch_stock);
                    }
                    dispatchInput.Dispatch_stock = listDispatch_Stock;
                }
                
               
                this._dispatchRep.UpdateDispatch(dispatchInput);*/
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void FixStock(DispatchDto dto)
        {
            try
            {
               var list = _dispatchRep.GetStockIdByDispatch(dto.ID);
                foreach (var item in list)
                {
                   var stock = dto.Stock.Where(x => x.ID == item.IdStock).FirstOrDefault();
                    item.Unity = stock.Unity;
                }
                _dispatchRep.UpdateDispatchStock(list);
            }catch(Exception ex)
            {
                throw ex;
            }

        }
        public async Task<ResultDto<DispatchDto>> GetDispatchFilter(DispatchFilterDto dto)
        {
            int number;
            Int32.TryParse(dto.Code, out number);
            dto.Code = number != 0 ? number.ToString() : "";
            var result = await this._dispatchRep.GetDispatchFilter(dto, ContextProvider.OfficeId);

            return this._mapper.Map<ResultDto<DispatchDto>>(result);
        }
    }
}

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
                var dispatchInput = _mapper.Map<Dispatch>(dispatch);
                dynamic result = this._dispatchRep.GetDispatchByOffice(dispatchInput);
                if(result == null)
                {
                    dispatchInput.IdUserOrigin = ContextProvider.UserId;
                    dispatchInput.DateCreate = DateTime.Now;
                    dispatchInput.IdState =  (int)Constants.Dispatch_State.Creado;
                    dispatchInput.Unity = 0;
                    result = this._dispatchRep.saveDispatch(dispatchInput);
                  
                }
                else
                {
                  result = GetDispatchById(result.ID).FirstOrDefault();
                }

                return _mapper.Map<DispatchDto>(result);
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

        public IEnumerable<DispatchDto> GetDispatchById(int id)
        {
            try
            {
                List<Dispatch> listDispatch = new List<Dispatch>();                
                Dispatch dispatch =  this._dispatchRep.GetDispatchById(id);
                // var dirStock = this._dispatchRep.GetStockIdByDispatch(dispatch.ID);             
                // dispatch.Stock = this._dispatchRep.GetStockByIdDispatch(dispatch.ID);
                List<Stock_Office> listStock_office = new List<Stock_Office>();
                dispatch.Stock = new List<Stock>();
                foreach (var item in dispatch.Dispatch_stock)
                {
                    var stock = this._stockRep.GetStockById(item.IdStock);
                    stock.Stock_Office = this._stockRep.GetStockOfficeByIdStock(stock);
                    dispatch.Stock.Add(stock);
                //    listStock_office.Add(this._stockRep.GetStock_Office(item.IdStock, dispatch.Origin));
                  
                }
                listDispatch.Add(dispatch);
              

               
                return _mapper.Map<IEnumerable<DispatchDto>>(listDispatch);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDispatch(DispatchDto dispatch)
        {
            try
            {
                var dispatchInput = _mapper.Map<Dispatch>(dispatch);
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
                
                switch (dispatchInput.IdState)
                {
                    case (int)Constants.Dispatch_State.Creado:
                        dispatchInput.IdState = (int)Constants.Dispatch_State.Creado;
                        dispatchInput.Unity = countBult;
                        break;
                    case (int)Constants.Dispatch_State.Despachado:
                        dispatchInput.IdState = (int)Constants.Dispatch_State.Despachado;
                        if (dispatchInput.DateDispatched == null)
                            dispatchInput.DateDispatched = DateTime.Now;
                        break;
                    case (int)Constants.Dispatch_State.Finalizado:
                        dispatchInput.IdState = (int)Constants.Dispatch_State.Finalizado;
                        foreach (var item in dispatchInput.Dispatch_stock)
                        {
                       //   var stock_officeDB =  this._stockRep.GetStock_Office(item.IdStock, dispatchInput.Destiny);
                      //    stock_officeDB.Unity += item.UnityRead;
                       //   this._stockRep.UpdateStockByOffice(stock_officeDB);
                        }
                        
                        break;
                    case (int)Constants.Dispatch_State.Incompleto:
                        dispatchInput.IdState = (int)Constants.Dispatch_State.Incompleto;
                        break;
                    case (int)Constants.Dispatch_State.Recibido:
                        dispatchInput.IdState = (int)Constants.Dispatch_State.Recibido;
                        if (dispatchInput.DateReceived == null)
                            dispatchInput.DateReceived = DateTime.Now;
                        dispatchInput.IdUserDestiny = ContextProvider.UserId;

                        break;
                }               
                this._dispatchRep.UpdateDispatch(dispatchInput);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<DispatchDto> GetDispatchFilter(DispatchFilterDto dto)
        {
            var result = this._dispatchRep.GetDispatchFilter(dto);

            return this._mapper.Map<IEnumerable<DispatchDto>>(result);
        }
    }
}

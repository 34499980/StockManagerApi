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
                if (dispatch.IdOrigin == dispatch.IdDestiny) throw new Business.Exceptions.BussinessException("errSameDestinationAndOrigin");
                
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

        public DispatchDto GetDispatchById(int id)
        {
            try
            {                          
                Dispatch dispatch =  this._dispatchRep.GetDispatchById(id);
               
                

               
                return _mapper.Map<DispatchDto>(dispatch);
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
                    dispatchDB.Dispatch_stock = this._mapper.Map<ICollection<Dispatch_Stock>>(dispatch.Dispatch_stock);
                }              
                foreach (var item in dispatchDB.Dispatch_stock)
                {
                    cantItems += item.Unity;
                    if (item.Unity == 0)
                    {
                        this._dispatchRep.removeDispatch(item);
                    }
                }
                switch (dispatchDB.IdState)
                {
                    case (int)Constants.Dispatch_State.Creado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Creado;
                        dispatchDB.Unity = cantItems;
                        break;
                    case (int)Constants.Dispatch_State.Despachado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Despachado;
                        if (dispatchDB.DateDispatched == null)
                            dispatchDB.DateDispatched = DateTime.Now;
                        break;
                    case (int)Constants.Dispatch_State.Finalizado:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Finalizado;                       

                        break;
                    case (int)Constants.Dispatch_State.Incompleto:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Incompleto;
                        break;
                    case (int)Constants.Dispatch_State.Recibido:
                        dispatchDB.IdState = (int)Constants.Dispatch_State.Recibido;
                        if (dispatchDB.DateReceived == null)
                            dispatchDB.DateReceived = DateTime.Now;
                        dispatchDB.IdUserDestiny = ContextProvider.UserId;

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
        public async Task<IEnumerable<DispatchDto>> GetDispatchFilter(DispatchFilterDto dto)
        {
            int number;
            Int32.TryParse(dto.Code, out number);
            dto.Code = number != 0 ? number.ToString() : "";
            var result = await this._dispatchRep.GetDispatchFilter(dto);

            return this._mapper.Map<IEnumerable<DispatchDto>>(result);
        }
    }
}

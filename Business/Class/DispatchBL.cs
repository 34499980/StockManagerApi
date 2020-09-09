using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstantControl;
using System.Text;

namespace Business.Class
{
    public class DispatchBL: IDispatchBL
    {
        private readonly IDispatchRep _dispatchRep;
        private readonly IUserRep _userhRep;
        private readonly ISucursalRep _sucursalRep;
        private readonly IStockRep _stockRep;
        public DispatchBL(IDispatchRep dispatchRep, IUserRep userRep, ISucursalRep sucursalRep, IStockRep stockRep)
        {
            this._dispatchRep = dispatchRep;
            this._userhRep = userRep;
            this._sucursalRep = sucursalRep;
            this._stockRep = stockRep;
        }
        /// <summary>
        /// Guarda despacho nuevo
        /// </summary>
        /// <param name="dispatch"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DispatchDto saveDispatch(DispatchDto dispatch,string user)
        {
            try
            {
              
                DispatchDto result = this._dispatchRep.GetDispatchBySucursales(dispatch);
                if(result == null)
                {                 
                    dispatch.IdUserOrigin = this._userhRep.GetUserByUserName(user).ID;
                    dispatch.DateCreate = DateTime.Now;
                    dispatch.IdState = this._dispatchRep.GetStates().Where(x => x.ID == (int)Constants.Dispatch_State.Creado).FirstOrDefault().ID;
                    dispatch.Unity = 0;
                    result = this._dispatchRep.saveDispatch(dispatch);
                }
                else
                {
                  result = GetDispatchById(result.ID).FirstOrDefault();
                }

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Trae todos los estados de un despacho
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Dispatch_StateDto> GetStates()
        {
            try
            {
                return this._dispatchRep.GetStates();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todos los despachos
        /// </summary>
        /// <returns></returns>

        public IEnumerable<DispatchDto> GetAllDispatchesBySucursal(string user)
        {
            try
            {
                UserDto userOrigin = this._userhRep.GetUserByUserName(user);
                var listDispatches = this._dispatchRep.GetAllDispatchesBySucursal(userOrigin.IdSucursal);
                if(listDispatches.Where(x => x.Destiny == userOrigin.IdSucursal).Any())
                {
                    listDispatches = listDispatches.Where( x => (x.Origin == userOrigin.IdSucursal) || (x.Destiny == userOrigin.IdSucursal && x.IdState != (int)Constants.Dispatch_State.Creado));
                }
                foreach (var item in listDispatches)
                {                    
                    item.UsuarioOrigin = this._userhRep.GetUserById(item.IdUserOrigin);
                    item.UsuarioDestiny = item.IdUserDestiny != null ? this._userhRep.GetUserById(item.IdUserDestiny.Value) : null;
                    item.SucDestiny = this._sucursalRep.GetSucursalById(item.Destiny);
                    item.SucOrigin = this._sucursalRep.GetSucursalById(item.Origin);
                    item.State = this._dispatchRep.GetStates().Where(x => x.ID == item.IdState).FirstOrDefault();
                }
                return listDispatches;
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
                List<DispatchDto> listDispatch = new List<DispatchDto>();
                List<Stock_SucursalDto> listStock_sucursal;
                DispatchDto dispatch =  this._dispatchRep.GetDispatchById(id);
                dispatch.UsuarioOrigin = this._userhRep.GetUserById(dispatch.IdUserOrigin);
                dispatch.UsuarioDestiny = dispatch.IdUserDestiny != null ? this._userhRep.GetUserById(dispatch.IdUserDestiny.Value) : null;
                var dirStock = this._dispatchRep.GetStockIdByDispatch(dispatch.ID);
                dispatch.Dispatch_stock = (IEnumerable<Dispatch_StockDto>)dirStock["dispatch_stock"];
                dispatch.Stock = (IEnumerable<StockDto>)dirStock["stock"];
                foreach (var item in dispatch.Stock)
                {
                    listStock_sucursal = new List<Stock_SucursalDto>();
                    listStock_sucursal.Add(this._stockRep.GetStock_Sucursal(item.ID,dispatch.Origin));
                    item.Stock_Sucursal = listStock_sucursal;
                  
                }
                listDispatch.Add(dispatch);
              

               
                return listDispatch;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDispatch(DispatchDto dispatch, string user)
        {
            try
            {
                int countBult = 0;
                Dispatch_StockDto dispatch_stock;
                //Stock_SucursalDto stock_sucursal;
                List<Dispatch_StockDto> listDispatch_Stock = new List<Dispatch_StockDto>();
                if (dispatch.Stock != null)
                {
                    foreach (var item in dispatch.Stock)
                    {
                        dispatch_stock = new Dispatch_StockDto();
                        dispatch_stock.IdDispatch = dispatch.ID;
                        dispatch_stock.IdStock = this._stockRep.GetStockByCode(item.QR).FirstOrDefault().ID;
                        dispatch_stock.Unity = item.Unity;
                        countBult += item.Unity;
                        listDispatch_Stock.Add(dispatch_stock);
                        //stock_sucursal = new Stock_SucursalDto();
                        //stock_sucursal.IdStock = dispatch_stock.IdStock;
                        //stock_sucursal.IdSucursal = dispatch.Origin;
                        //stock_sucursal.Unity = item.Unity;

                        Stock_SucursalDto stock_sucursalDB = this._stockRep.GetStock_Sucursal(dispatch_stock.IdStock, dispatch.Origin);
                        //stock_sucursalDB.Unity = stock_sucursalDB.Unity - stock_sucursal.Unity;

                        this._stockRep.UpdateStockBySucursal(item.Stock_Sucursal.Where(x => x.IdStock == dispatch_stock.IdStock && x.IdSucursal == dispatch.Origin).FirstOrDefault());


                    }
                    dispatch.Dispatch_stock = listDispatch_Stock;
                }
                dispatch.Unity = countBult;
                switch (dispatch.IdState)
                {
                    case (int)Constants.Dispatch_State.Creado:
                        dispatch.IdState = (int)Constants.Dispatch_State.Creado;
                        break;
                    case (int)Constants.Dispatch_State.Despachado:
                        dispatch.IdState = (int)Constants.Dispatch_State.Despachado;
                        dispatch.DateDispatched = DateTime.Now;
                        break;
                    case (int)Constants.Dispatch_State.Finalizado:
                        dispatch.IdState = (int)Constants.Dispatch_State.Finalizado;                        
                        break;
                    case (int)Constants.Dispatch_State.Incompleto:
                        dispatch.IdState = (int)Constants.Dispatch_State.Incompleto;
                        break;
                    case (int)Constants.Dispatch_State.Recibido:
                        dispatch.IdState = (int)Constants.Dispatch_State.Recibido;
                        dispatch.DateRecived = DateTime.Now;
                        dispatch.IdUserDestiny = this._userhRep.GetUserByUserName(user).ID;

                        break;
                }               
                this._dispatchRep.UpdateDispatch(dispatch);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstantControl;
using System.Text;

namespace Repository.Class
{
    public class DispatchRep : IDispatchRep
    {
        private readonly StockManagerContext _context;
        public DispatchRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Graba un nuevo despacho y devuelve su id
        /// </summary>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public DispatchDto saveDispatch(DispatchDto dispatch)
        {
            try
            {
                this._context.DISPATCH.Add(dispatch);
                this._context.SaveChanges();
                return dispatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todos los estados que puede tener un despacho
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dispatch_StateDto> GetStates()
        {
            try
            {
                return this._context.DISPATCH_STATE.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todos los despachos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DispatchDto> GetAllDispatchesBySucursal(int idSucursal)
        {
            try
            {
                //TODO probar despacho con sucursal
                dynamic result = null;
               result = this._context.DISPATCH.Include(q => q.UsuarioDestiny)
                                              .Include(q => q.UsuarioOrigin)
                                              .Include(q => q.State)
                                              .Include(q => q.Dispatch_stock)
                                              .Where(x => x.Origin == idSucursal || x.Destiny == idSucursal).ToList();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca despacho por id pasado por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DispatchDto GetDispatchById(int id)
        {
            try
            {
                //TODO PROBAR traer despacho con stock              
                return this._context.DISPATCH .Include(q => q.UsuarioDestiny)
                                              .Include(q => q.UsuarioOrigin)
                                              .Include(q => q.State)
                                              .Include(q => q.Dispatch_stock)
                                              .Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca el stock que tiene asignado un despacho
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Dispatch_StockDto> GetStockIdByDispatch(int id)
        {
            try
            {
                //Dictionary<string, object> result = new Dictionary<string, object>();
                //StockDto stock = null;
                //List<StockDto> listStock = new List<StockDto>();
                var result = this._context.DISPATCH_STOCK.Include(q => q.Stock).Where(x => x.IdDispatch == id).ToList();

                //foreach (var item in dispatch_Stock)
                //{
                //   stock =  this._context.STOCK.Where(x => x.ID == item.IdStock).FirstOrDefault();
                //   listStock.Add(stock);
                //}
                //result.Add("stock", listStock);
                //result.Add("dispatch_stock", dispatch_Stock);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public ICollection<StockDto> GetStockByIdDispatch(int id)
        {
            try
            {
                //Dictionary<string, object> result = new Dictionary<string, object>();
                //StockDto stock = null;
                //List<StockDto> listStock = new List<StockDto>();
                var result = this._context.DISPATCH.Where(x => x.ID == id).SelectMany(q => q.Dispatch_stock).Select(q => q.Stock).ToList();
                    //this._context.DISPATCH.SelectMany(q => q.Dispatch_stock).Select(q => q.Stock).Where(x => x.ID == id).ToList();

                //foreach (var item in dispatch_Stock)
                //{
                //   stock =  this._context.STOCK.Where(x => x.ID == item.IdStock).FirstOrDefault();
                //   listStock.Add(stock);
                //}
                //result.Add("stock", listStock);
                //result.Add("dispatch_stock", dispatch_Stock);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve los despachos por sucursal de origen y destino
        /// </summary>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public DispatchDto GetDispatchBySucursales(DispatchDto dispatch)
        {
            try
            {
                dynamic result = null;              
               result = this._context.DISPATCH.Where(x => x.Origin == dispatch.Origin && x.Destiny == dispatch.Destiny && x.IdState == (int)Constants.Dispatch_State.Creado).FirstOrDefault();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza el stock del despacho
        /// </summary>
        /// <param name="dispatch"></param>
        public  void UpdateDispatch(DispatchDto dispatch)
        {
            try
            {
              
                var Dispatch_stockDB = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == dispatch.ID).ToList();
                var dispatchDB = this._context.DISPATCH.Where(x => x.ID == dispatch.ID).FirstOrDefault();
                if (dispatch.Dispatch_stock != null)
                {
                    foreach (var item in dispatch.Dispatch_stock)
                    {
                        var dispatch_stockDB = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == item.IdDispatch && x.IdStock == item.IdStock).FirstOrDefault();
                        if (dispatch_stockDB != null)
                        {
                            if (item.Unity > 0)
                            {
                                dispatch_stockDB.Unity = item.Unity;
                                dispatch_stockDB.UnityRead = item.UnityRead;
                                this._context.Entry(dispatch_stockDB).State = EntityState.Modified;
                            }
                            else
                            {
                                this._context.DISPATCH_STOCK.Remove(dispatch_stockDB);
                            }

                        }
                        else
                        {
                            this._context.DISPATCH_STOCK.Add(item);
                        }
                        this._context.SaveChanges();
                    }
                }
                dispatchDB.Unity = dispatch.Unity;
                dispatchDB.IdState = dispatch.IdState;
                dispatchDB.DateDispatched = dispatch.DateDispatched;
                dispatchDB.DateRecived = dispatch.DateRecived;
                dispatchDB.IdUserDestiny = dispatch.IdUserDestiny;
                dispatchDB.IdState = dispatch.IdState;

                this._context.Entry(dispatchDB).State = EntityState.Modified;

                this._context.SaveChanges();



            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

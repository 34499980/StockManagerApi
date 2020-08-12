using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<DispatchDto> GetAllDispatches()
        {
            try
            {
               return this._context.DISPATCH.ToList();
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
                return this._context.DISPATCH.Where(x => x.ID == id).FirstOrDefault();
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
        public Dictionary<string,object> GetStockIdByDispatch(int id)
        {
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                StockDto stock = null;
                List<StockDto> listStock = new List<StockDto>();
               var dispatch_Stock = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == id).ToList();

                foreach (var item in dispatch_Stock)
                {
                   stock =  this._context.STOCK.Where(x => x.ID == item.IdStock).FirstOrDefault();
                   listStock.Add(stock);
                }
                result.Add("stock", listStock);
                result.Add("dispatch_stock", dispatch_Stock);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public DispatchDto GetDispatchBySucursales(DispatchDto dispatch)
        {
            try
            {
               return this._context.DISPATCH.Where(x => x.Origin == dispatch.Origin && x.Origin == dispatch.Destiny && x.State.Description == "Creado").FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDispatch(DispatchDto dispatch)
        {
            try
            {
              
                var Dispatch_stock = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == dispatch.ID).ToList();
                foreach (var item in Dispatch_stock)
                {
                    this._context.DISPATCH_STOCK.Remove(item);
                }
                this._context.SaveChanges();
               
                foreach (var item in dispatch.Dispatch_stock)
                {                    
                    this._context.DISPATCH_STOCK.Add(item);
                }               
               
                this._context.Entry(dispatch).State = EntityState.Modified;               
                this._context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

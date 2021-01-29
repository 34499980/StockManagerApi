using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstantControl;
using System.Text;
using Repository.Entities;
using DTO.Class;
using System.Threading.Tasks;

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
        public Dispatch saveDispatch(Dispatch dispatch)
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
        /// Devuelve todos los despachos
        /// </summary>
        /// <returns></returns>
        /// 
        public IEnumerable<Dispatch> GetAllDispatchesByOffice(int idOffice)
        {
            try
            {
                //TODO probar despacho con sucursal
                dynamic result = null;
               result = this._context.DISPATCH.Include(q => q.UserDestiny)
                                              .Include(q => q.UserOrigin)
                                              .Include(q => q.State)
                                              .Where(x => x.IdOrigin == idOffice|| x.IdDestiny == idOffice).ToList();
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
        public Dispatch GetDispatchById(int id)
        {
            try
            {
                //TODO PROBAR traer despacho con stock              
                return this._context.DISPATCH .Include(q => q.UserDestiny)
                                              .Include(q => q.UserOrigin)
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
        public ICollection<Dispatch_Stock> GetStockIdByDispatch(int id)
        {
            try
            {
                var result = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == id).ToList();

                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve el stock que tiene un despacho
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Stock> GetStockByIdDispatch(int id)
        {
            try
            {
              
                var result = this._context.STOCK.Where(x => x.ID == id).ToList();


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
        public Dispatch GetDispatchByOffice(Dispatch dispatch)
        {
            try
            {
                dynamic result = null;              
               result = this._context.DISPATCH.Include(q => q.UserOrigin)
                                              .Include(q => q.UserDestiny)
                                              .Where(x => x.IdOrigin == dispatch.IdOrigin && 
                                                    x.IdDestiny == dispatch.IdDestiny && 
                                                    x.IdState == (int)Constants.Dispatch_State.Creado)
                                              .FirstOrDefault();
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
        public  void UpdateDispatch(Dispatch dispatch)
        {
            try
            {

                var Dispatch_stockDB = this._context.DISPATCH_STOCK.Where(x => x.IdDispatch == dispatch.ID).ToList();
                //var dispatchDB = this._context.DISPATCH.Where(x => x.ID == dispatch.ID).FirstOrDefault();
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
                //dispatchDB.Unity = dispatch.Unity;
                //dispatchDB.IdState = dispatch.IdState;
                //dispatchDB.DateDispatched = dispatch.DateDispatched;
                //dispatchDB.DateRecived = dispatch.DateRecived;
                //dispatchDB.IdUserDestiny = dispatch.IdUserDestiny;
                //dispatchDB.IdState = dispatch.IdState;

                this._context.Entry(dispatch).State = EntityState.Modified;

                this._context.SaveChanges();



            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Dispatch>> GetDispatchFilter(DispatchFilterDto dto)
        {
            try
            {
                var result = await this._context.DISPATCH.Include(q => q.UserOrigin)
                                                          .Include(q => q.UserDestiny)
                                                          .Include(q => q.OfficeOrigin)
                                                          .Include(q => q.officeDestiny)
                                                          .Include(q => q.State)
                                                          .Where(x => (dto.UserName == "" || x.UserOrigin.UserName.Contains(dto.UserName) ||
                                                               dto.UserName == "" || x.UserDestiny.UserName.Contains(dto.UserName)) &&
                                                               dto.CreatedDateFrom == null || x.DateCreate == dto.CreatedDateFrom &&
                                                               dto.CreatedDateTo == null || x.DateCreate == dto.CreatedDateTo &&
                                                               dto.DispatchedDateFrom == null || x.DateDispatched == dto.DispatchedDateFrom &&
                                                               dto.DispatchedDateTo == null || x.DateDispatched == dto.DispatchedDateTo &&
                                                               dto.RecceivedDateFrom == null || x.DateReceived == dto.RecceivedDateFrom &&
                                                               dto.ReceivedDateTo == null || x.DateReceived == dto.ReceivedDateTo && 
                                                               dto.IdState == null || x.IdState == dto.IdState &&
                                                               dto.Code == "" || x.ID.ToString() == dto.Code &&
                                                               dto.IdDestiny == null || x.IdDestiny == dto.IdDestiny &&
                                                               x.OfficeOrigin.IdCountry == dto.IdCountry
                                                        ).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

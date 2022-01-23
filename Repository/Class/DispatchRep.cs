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
                                              .Include(q => q.Dispatch_stock)                                            
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
                this._context.Update(dispatch);
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDispatchStock(IEnumerable<Dispatch_Stock> stock)
        {
            try
            {
                this._context.UpdateRange(stock);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void addDispatch_stock(Dispatch_Stock dispatch_stock)
        {
            try
            {
                this._context.DISPATCH_STOCK.Add(dispatch_stock);
                 this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void removeDispatch(Dispatch_Stock dispatch_stock)
        {
            try
            {
                this._context.DISPATCH_STOCK.RemoveRange(dispatch_stock);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Dispatch>> GetDispatchFilter(DispatchFilterDto dto, int idOrigin)
        {
            try
            {
                var query =  this._context.DISPATCH.Include(q => q.UserOrigin)
                                                          .Include(q => q.UserDestiny)
                                                          .Include(q => q.OfficeOrigin)
                                                          .Include(q => q.officeDestiny)
                                                          .Include(q => q.State)
                                                          .Where(x =>
                                                               // ((dto.UserName == "" || dto.UserName == null) || x.UserOrigin.UserName.Contains(dto.UserName) ||
                                                             //  (dto.UserName == "" || dto.UserName == null) || x.UserDestiny.UserName.Contains(dto.UserName)) &&
                                                               (dto.CreatedDateFrom == null || x.DateCreate.Date == dto.CreatedDateFrom.Value.Date) &&
                                                               (dto.CreatedDateTo == null || x.DateCreate.Date == dto.CreatedDateTo.Value.Date) &&
                                                              // (dto.DispatchedDateFrom == null || x.DateDispatched.Value.Date == dto.DispatchedDateFrom.Value.Date) &&
                                                              // (dto.DispatchedDateTo == null || x.DateDispatched.Value.Date == dto.DispatchedDateTo.Value.Date) &&
                                                               (dto.RecceivedDateFrom == null || x.DateReceived.Value.Date == dto.RecceivedDateFrom.Value.Date) &&
                                                               (dto.ReceivedDateTo == null || x.DateReceived.Value.Date == dto.ReceivedDateTo.Value.Date) &&
                                                              // (dto.IdState == null || x.IdState == dto.IdState) &&
                                                             //  (dto.Code == "" || x.ID.ToString() == dto.Code) &&
                                                              // (dto.IdDestiny == null || x.IdDestiny == dto.IdDestiny) &&
                                                              // (x.OfficeOrigin.IdCountry == dto.IdCountry) &&
                                                               (x.IdOrigin == idOrigin || x.IdDestiny == idOrigin)
                                                        );
                var page = await query.Skip((dto.PageIndex - 1) * dto.PageSize)
                     .Take(dto.PageSize)
                    .ToListAsync();

                return new Result<Dispatch> { rowCount = query.Count(), data = page };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

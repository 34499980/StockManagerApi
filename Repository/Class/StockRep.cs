using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class StockRep : IStockRep
    {
        private readonly StockManagerContext _context;
        public StockRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Busca el stock por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock GetStockByCode(string qr)
        {
            try
            {               
                return this._context.STOCK.Include(q => q.Stock_Office).Where(x => x.QR == qr).FirstOrDefault();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca todo el stock
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetAllStock()
        {
            try
            {
                return this._context.STOCK.ToList();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Guarda el stock nuevo
        /// </summary>
        /// <param name="stock"></param>
        public long SaveStock(Stock stock)
        {
            try
            {
                this._context.STOCK.Add(stock);
                this._context.SaveChanges();

                return stock.ID;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza los datos de stock
        /// </summary>
        /// <param name="stock"></param>
        public void UpdateStock(Stock stock)
        {
            try
            {
                this._context.Entry(stock).State = EntityState.Modified;               
                this._context.SaveChanges();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve los estados que puede tener el stock
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock_State> GetAllStates()
        {
            try
            {
                return this._context.STOCK_STATE.ToList();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Al crear el stock, se genera por cada sucursal por lo menos con valor 0
        /// </summary>
        /// <param name="stock"></param>
     
        /// <summary>
        /// Devuelve todas las unidades de stock que tiene por sucursal
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public Stock_Office GetStock_Office(long idStock, int idSucursal)
        {
            try
            {
                var result = this._context.STOCK_OFFICE.Where(x => x.IdStock == idStock && x.IdOffice == idSucursal).FirstOrDefault();
                return result;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve el stock de todas las sucursales por un idstock
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ICollection<Stock_Office> GetStockOfficeByIdStock(Stock stock)
        {
            try
            {
                var result = this._context.STOCK_OFFICE.Include(x => x.Office).Include(x => x.Stock).Where(x => x.IdStock == stock.ID ).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve un listado de stock por parametros puestos en un where
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<Stock> GetStockByParams(string param,string name)
        {
            try
            {              
                var result = this._context.STOCK.FromSqlRaw<Stock>(name, param).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualizo unidades de stock por sucursal
        /// </summary>
        /// <param name="stock"></param>
        public  void UpdateStockByOffice(ICollection<Stock_Office> stock)
        {
            try
            {
                this._context.STOCK_OFFICE.UpdateRange(stock);
                 this._context.SaveChanges();
               

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve stock por el id de base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock GetStockById(long id)
        {
            try
            {
                return this._context.STOCK.Include(x => x.Stock_Office)
                                          .Include(x => x.Office)
                                          .Where(x => x.ID == id)
                                          .Select(stock => new Stock
                                          {
                                              ID = stock.ID,
                                              Code = stock.Code,
                                              QR = stock.QR,
                                              Name = stock.Name,
                                              Brand = stock.Brand,
                                              Model = stock.Model,
                                              Description = stock.Description,
                                              File = stock.File,
                                              IdOffice = stock.IdOffice,
                                              IdState = stock.IdState,
                                              State = stock.State,
                                              Stock_Office = stock.Stock_Office,
                                              Office = stock.Office
                                          }).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<dynamic> GetOfficeFilter(StockFilterDto dto)
        {
            try
            {
                var query =  this._context.STOCK_OFFICE.Include(x => x.Stock)
                                                       .Include(x => x.Office)
                                                      .Where(x => (dto.Name == null || x.Stock.Name.Contains(dto.Name)) &&
                                                        (dto.Code == null || x.Stock.QR.Contains(dto.Code)) &&
                                                        (dto.Brand == null || x.Stock.Brand.Contains(dto.Brand)) &&
                                                        (dto.Model == null || x.Stock.Model.Contains(dto.Model)) &&
                                                        (dto.IdCountry == null || x.Office.IdCountry == dto.IdCountry) &&
                                                        (dto.IdOffice == null || x.IdOffice == dto.IdOffice));

             var page = await  query.Select(stock => new Stock_Office
                                                {
                                                    ID = stock.ID,
                                                    IdOffice = stock.IdOffice,
                                                    IdStock = stock.IdStock,
                                                    Unity = stock.Unity,
                                                    Office = stock.Office,
                                                    Stock = stock.Stock
                                                }).Skip((dto.PageIndex - 1) * dto.PageSize)
                     .Take(dto.PageSize)
                    .ToListAsync();

            

                return new Result<Stock_Office> {rowCount = query.Count(), data = page };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(int id)
        {
            try
            {
                var stock_office =  this._context.STOCK_OFFICE.Where(x => x.IdStock == id).ToList();
                var stock_dispatch =  this._context.DISPATCH_STOCK.Where(x => x.IdStock == id).ToList();
                var stock = this._context.STOCK.Where(x => x.ID == id).FirstOrDefault();
                this._context.STOCK_OFFICE.RemoveRange(stock_office);
                this._context.DISPATCH_STOCK.RemoveRange(stock_dispatch);
                this._context.STOCK.Remove(stock);
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}

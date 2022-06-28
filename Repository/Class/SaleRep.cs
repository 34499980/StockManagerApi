using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class SaleRep : ISaleRep
    {
        private readonly StockManagerContext _context;
        public SaleRep(StockManagerContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Graba una nueva venta y devuelve su id
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public async Task<Sale> save(Sale sale)
        {
            try
            {
                this._context.SALE.Add(sale);
                await this._context.SaveChangesAsync();
                return sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Trae las ventas filtradas
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<Sale>> GetSalesByFilters(SaleFilterDto dto)
        {
            try
            {
                var query = _context.SALE.Include(q => q.Office)
                                         .Include(q => q.State)
                                         .Include(q => q.User)
                                         .Where(x =>
                                                   dto.Id == null || x.ID == dto.Id &&
                                                   dto.IdOffice == null || x.IdOffice == dto.IdOffice &&
                                                   dto.IdState == null || x.IdState == dto.IdState &&
                                                   dto.IdUser == null || x.IdUser == dto.IdUser &&
                                                   dto.DateProcesFrom == null || x.DateProces.Date >= dto.DateProcesFrom.Value.Date &&
                                                   dto.DateProcesTo == null || x.DateProces.Date <= dto.DateProcesTo.Value.Date).OrderByDescending(x => x.DateProces);

                var page = await query.Skip((dto.PageIndex - 1) * dto.PageSize)
                    .Take(dto.PageSize)
                   .ToListAsync();

                return new Result<Sale> { rowCount = query.Count(), data = page };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Sale> GetStockBySaleId(long id)
        {
            try
            {
                return await this._context.SALE.Include(q => q.Sale_stock).Where(x => x.ID == id).FirstOrDefaultAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Sale> GetSaleById(long id)
        {
            try
            {
                return await _context.SALE.Include(q => q.Sale_stock)
                                    .Where(x => x.ID == id).FirstOrDefaultAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(Sale sale)
        {
            try
            {
                this._context.Update(sale);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

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
    public class DiscountRep : IDiscountRep
    {
        private readonly StockManagerContext _context;
        public DiscountRep(StockManagerContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountByOffice(int idOffice)
        {
            return await _context.DISCOUNT_OFFICE.Include(q => q.DISCOUNT)
                                                 .Where(x => x.IdOffice == idOffice)
                                                 .Select(x => x.DISCOUNT).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            return await _context.DISCOUNT.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Result<Discount>> GetDiscountFilter(DiscountFilterDto dto)
        {
            var query = this._context.DISCOUNT.Include(q => q.User)
                                                          .Include(q => q.Stock)
                                                          .Include(q => q.PaymentType)
                                                         // .Include(q => q.Discount_Office)
                                                          .Where(x =>
                                                                    dto.CreateFrom == null || x.DateFrom.Date >= dto.CreateFrom.Value.Date &&
                                                                    dto.CreateTo == null || x.DateTo.Date <= dto.CreateTo.Value.Date &&
                                                                    dto.PercentFrom == null || x.Percent >= dto.PercentFrom &&
                                                                    dto.PercentTo == null || x.Percent <= dto.PercentTo
                                                          
                                                              
                                                        );
         /*   var query = this._context.DISCOUNT_OFFICE.Include(q => q.DISCOUNT)
                                                          .Where(x =>
                                                                    dto.IdOffice == null || x.IdOffice >= dto.IdOffice


                                                        );*/
        
            var page = await query.Skip((dto.PageIndex - 1) * dto.PageSize)
                 .Take(dto.PageSize)
                .ToListAsync();
         /*   page = page.Where(x =>
                            dto.CreateFrom == null || x.DISCOUNT.DateFrom.Date >= dto.CreateFrom.Date &&
                            dto.CreateTo == null || x.DISCOUNT.DateTo.Date <= dto.CreateTo.Date &&
                            dto.PercentFrom == null || x.DISCOUNT.Percent >= dto.PercentFrom &&
                            dto.PercentTo == null || x.DISCOUNT.Percent <= dto.PercentTo);*/
            return new Result<Discount> { rowCount = query.Count(), data = page };
        }

        public async Task removeDiscount(int IdDiscount)
        {
          var entity =  await _context.DISCOUNT.Where(x => x.ID == IdDiscount).FirstOrDefaultAsync();
          var list =  await _context.DISCOUNT_OFFICE.Where(x => x.ID == IdDiscount).ToListAsync();
            _context.DISCOUNT_OFFICE.RemoveRange(list);
            _context.DISCOUNT.Remove(entity);
           await  _context.SaveChangesAsync();
        }

        public async Task<Discount> saveDiscount(Discount discount)
        {
            await _context.DISCOUNT.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task UpdateDiscount(Discount discount)
        {
             _context.DISCOUNT.Update(discount);
            await _context.SaveChangesAsync();
        }
    }
}

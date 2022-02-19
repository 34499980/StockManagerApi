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
            throw new NotImplementedException();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Discount>> GetDiscountFilter(DiscountFilterDto dto, int idOrigin)
        {
            throw new NotImplementedException();
        }

        public async Task removeDiscount(int IdDiscount)
        {
            throw new NotImplementedException();
        }

        public async Task<Discount> saveDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}

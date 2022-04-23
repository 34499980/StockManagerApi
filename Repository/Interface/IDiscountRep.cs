using DTO.Class;
using Repository.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDiscountRep
    {
        Task<Discount> saveDiscount(Discount discount);      
        Task<IEnumerable<Discount>> GetAllDiscountByOffice(int idOffice);
        Task<Discount> GetDiscountById(int id);
    
        Task UpdateDiscount(Discount discount);
     
        Task<Result<Discount>> GetDiscountFilter(DiscountFilterDto dto);
        Task removeDiscount(int IdDiscount);
        Task<Discount> GetDiscountsByDates(DateTime start, DateTime end, long? idStock);
        Task<PaymentType> GetPaymentTypeById(int Id);


    }
}

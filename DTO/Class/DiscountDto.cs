using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class DiscountDto
    {
        public long ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Percent { get; set; }
       // public int IdPaymentType { get; set; }
        public long IdStock { get; set; }
        public int IdUser { get; set; }
        public bool State { get; set; }
        //    public virtual string PaymentTypeDescription { get { return PaymentType.Description; } }

        public virtual string StockDescription { get { return Stock?.Description; } }

        public virtual string UserDescription { get { return User?.UserName; } }

        public virtual IEnumerable<Discount_PaymentTypeDto> PaymentTypeList { get; set; }
        // public virtual PaymentTypeDto PaymentType { get; set; }  

        public virtual StockDto Stock { get; set; }
      
        public virtual UserDto User { get; set; }
        public virtual IEnumerable<OfficeDto> Offices { get; set; }
        public virtual IEnumerable<ItemDto> PaymentType { get; set; }
    }
}

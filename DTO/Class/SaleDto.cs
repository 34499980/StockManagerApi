using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
 
    public class SaleDto
    {
     
        public int ID { get; set; }
        public DateTime DateProces { get; set; }
        public int IdUser { get; set; }
        public decimal Amount { get; set; }
        public string Refer { get; set; }
        public int IdOffice { get; set; }
        public int IdState { get; set; }
        public PaymentTypeDto PaymentTypeDto { get; set; }

        public string OfficeDescription { get { return Office?.Name; } }
        public string UseDescription { get { return User?.UserName; } }
        public string StateDescription { get { return State?.Descripcion; } }

        public  OfficeDto Office { get; set; }
        public ICollection<Sale_StockDto> Sale_stock { get; set; }
        public ICollection<StockDto> Stock { get; set; }

        public  Sale_StateDto State { get; set; }
       
        public  UserDto User { get; set; }

    }
}

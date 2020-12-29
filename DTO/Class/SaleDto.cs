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
        public float Amount { get; set; }
        public string Refer { get; set; }
        public int IdSucursal { get; set; }
        public int IdState { get; set; }


       
        public  OfficeDto Sucursal { get; set; }

       
        public  Sale_StateDto State { get; set; }
       
        public  UserDto User { get; set; }

    }
}

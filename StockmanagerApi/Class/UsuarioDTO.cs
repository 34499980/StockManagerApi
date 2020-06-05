using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockmanagerApi.Class
{
    public class UsuarioDTO
    {
       

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LASTNAME { get; set; }
        public System.DateTime DateBorn { get; set; }
        public System.DateTime DateAdmission { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int IdSucursal { get; set; }

        public List<Object>  SALE { get; set; }
        public List<Object> SUCURSAL  { get; set; }
    }
}
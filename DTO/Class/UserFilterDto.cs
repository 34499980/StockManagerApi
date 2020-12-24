using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class UserFilterDto
    {
        public string UserName { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdRole { get; set; }
        public bool Active { get; set; }
    }
}

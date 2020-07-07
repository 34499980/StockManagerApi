﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("USUARIO", Schema = "dbo")]
    public class UserDto
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime DateAdmission { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int IdSucursal { get; set; }

        [ForeignKey("IdSucursal")]

        public virtual SucursalDto Sucursal { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace Repository.Entities
{
    [Table("USERS", Schema = "dbo")]
    public class User
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
        public int IdRole { get; set; }
        public bool Active { get; set; }

        [ForeignKey("IdSucursal")]

        public virtual Sucursal Sucursal { get; set; }
        [ForeignKey("IdRole")]
        public virtual Roles Role { get; set; }
    }
}

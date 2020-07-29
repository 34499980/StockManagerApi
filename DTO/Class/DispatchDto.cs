using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("DISPATCH", Schema = "dbo")]
    public class DispatchDto
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public int IdUser { get; set; }
        public int Origin { get; set; }
        public int Destiny { get; set; }
        public int IdState { get; set; }
        public DateTime DateDispatched { get; set; }
        public DateTime DateRecived { get; set; }
        public int Unity { get; set; }

        public virtual UserDto Usuario { get; set; }
        public virtual SucursalDto SucOrigin { get; set; }
        public virtual SucursalDto SucDestiny { get; set; }
        public virtual Dispatch_StateDto State { get; set; }
    }
}

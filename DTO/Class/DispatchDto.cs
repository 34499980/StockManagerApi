using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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
        public DateTime? DateDispatched { get; set; }
        public DateTime? DateRecived { get; set; }
        public int? Unity { get; set; }

        
        [ForeignKey("IdUser")]
        public virtual UserDto Usuario { get; set; }
        [ForeignKey("Origin")]
        public virtual SucursalDto SucOrigin { get; set; }
        [ForeignKey("Destiny")]
        public virtual SucursalDto SucDestiny { get; set; }
        [ForeignKey("IdState")]
        public virtual Dispatch_StateDto State { get; set; }
        [JsonIgnore]
        public virtual ICollection<StockDto> Stock { get; set; }
        public virtual string Code
        {
            get { return ID.ToString().PadLeft(10,'0'); }
           
        }

    }
}

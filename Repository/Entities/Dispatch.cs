using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    [Table("DISPATCH", Schema = "dbo")]
    public class Dispatch
    {

        [Key]
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public int IdUserOrigin { get; set; }
        public int? IdUserDestiny { get; set; }
        public int IdOrigin { get; set; }
        public int IdDestiny { get; set; }
        public int IdState { get; set; }
        public DateTime? DateDispatched { get; set; }
        public DateTime? DateReceived { get; set; }
        public int Unity { get; set; }


        [ForeignKey("IdUserOrigin")]
        public virtual User UserOrigin { get; set; }
        [ForeignKey("IdUserDestiny")]
        public virtual User UserDestiny { get; set; }
        [ForeignKey("IdOrigin")]
        public virtual Office OfficeOrigin { get; set; }
        [ForeignKey("IdDestiny")]
        public virtual Office officeDestiny { get; set; }
        [ForeignKey("IdState")]
        public virtual Dispatch_State State { get; set; }
        [NotMapped]
        public  ICollection<Stock> Stock { get; set; }       
        public virtual ICollection<Dispatch_Stock> Dispatch_stock { get; set; }
        public virtual string Code
        {
            get { return ID.ToString().PadLeft(10,'0'); }
           
        }

    }
}

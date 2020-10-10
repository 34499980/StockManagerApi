using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    [Table("DISPATCH_STOCK", Schema = "dbo")]
    public class Dispatch_Stock
    {
        [Key]
        public int ID { get; set; }
        public int IdDispatch { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }
        public int UnityRead { get; set; }

        [ForeignKey("IdDispatch")]
        public virtual Dispatch Dispatch { get; set; }       
        //[ForeignKey("IdStock")]
        //public virtual Stock Stock { get; set; }
    }
}

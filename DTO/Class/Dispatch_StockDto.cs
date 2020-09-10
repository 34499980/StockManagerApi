using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DTO.Class
{
    [Table("DISPATCH_STOCK", Schema = "dbo")]
    public class Dispatch_StockDto
    {
        [Key]
        public int ID { get; set; }
        public int IdDispatch { get; set; }
        public long IdStock { get; set; }
        public int Unity { get; set; }
        public int UnityRead { get; set; }

        [JsonIgnore]
        [ForeignKey("IdDispatch")]
        public virtual DispatchDto Dispatch { get; set; }
        [JsonIgnore]
        [ForeignKey("IdStock")]
        public virtual StockDto Stock { get; set; }
    }
}

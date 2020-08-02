using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("DISPATCH_STOCK", Schema = "dbo")]
    public class Dispatch_StockDto
    {
        [Key]
        public int IdDispatch { get; set; }
        public int IdStock { get; set; }
        public int Unity { get; set; }
    }
}

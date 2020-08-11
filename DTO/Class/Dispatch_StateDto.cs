using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("DISPATCH_STATE", Schema = "dbo")]
    public class Dispatch_StateDto : StateBaseDto
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}

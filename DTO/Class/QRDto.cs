using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("QR", Schema = "dbo")]
    public class QRDto
    {       
       
        public long ID { get; set; }
        public long? IdStock { get; set; }   
       
       
    }
}

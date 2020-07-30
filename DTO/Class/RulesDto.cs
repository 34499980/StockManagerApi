using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("RULES", Schema = "dbo")]
    public class RulesDto
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("ACTIONS", Schema = "dbo")]
    public class Actions
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}

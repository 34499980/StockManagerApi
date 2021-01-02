using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("COUNTRY", Schema = "dbo")]
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    }
}

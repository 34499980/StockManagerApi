using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    [Table("HISTORY", Schema = "dbo")]
    public class History
    {

        [Key]
        public int ID { get; set; }
        public DateTime DateProces { get; set; }
        public int IdUser { get; set; }
        public string Action { get; set; }
        public string ActionDetail { get; set; }
        public string Refer { get; set; }       


        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
      

    }
}

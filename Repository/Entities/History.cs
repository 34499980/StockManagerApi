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
        public long ID { get; set; }
        public DateTime DateProces { get; set; }
        public int IdUser { get; set; }

        public int IdOffice { get; set; }
        public int IdAction { get; set; }
        public string SubAction { get; set; }
        public string ActionDetail { get; set; }   


        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        [ForeignKey("IdOffice")]
        public virtual Office Office { get; set; }
        [ForeignKey("IdAction")]
        public virtual Item Action { get; set; }


    }
}

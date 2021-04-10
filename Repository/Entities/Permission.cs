using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("PERMISSION", Schema = "dbo")]
    public class Permission
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }

        public int ModuleId { get; set; }
        public int ValueId { get; set; }
    }
}

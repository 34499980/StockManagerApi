using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("RULES_PERMISSION", Schema = "dbo")]
    public class Rules_Permission
    {
        [Key]
        public int IdRule { get; set; }
        public int IdPermission {get;set;}
        public int Read { get; set; }
        public int Write { get; set; }

        [ForeignKey("IdRule")]
        public virtual Rules Rule { get; set; }
        [ForeignKey("IdPermission")]
        public virtual Permission Permission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
    [Table("RULES_PERMISSION", Schema = "dbo")]
    public class Rules_PermissionDto
    {
        [Key]
        public int IdRule { get; set; }
        public int IdPermission {get;set;}
        public int Read { get; set; }
        public int Write { get; set; }

        [ForeignKey("IdRule")]
        public virtual RulesDto Rule { get; set; }
        [ForeignKey("IdPermission")]
        public virtual PermissionDto Permission { get; set; }
    }
}

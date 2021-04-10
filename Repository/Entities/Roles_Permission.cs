using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    [Table("ROLES_PERMISSION", Schema = "dbo")]
    public class Roles_Permission
    {
        [Key]
        public int IdRole { get; set; }
        public int IdPermission {get;set;}
        public int Read { get; set; }
        public int Write { get; set; }

        [ForeignKey("IdRole")]
        public virtual Roles Role { get; set; }
        [ForeignKey("IdPermission")]
        public virtual Permission Permission { get; set; }
    }
}

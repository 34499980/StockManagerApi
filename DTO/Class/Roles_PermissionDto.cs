using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
 
    public class Roles_PermissionDto
    {
      
        public int IdRole { get; set; }
        public int IdPermission {get;set;}
        public int Read { get; set; }
        public int Write { get; set; }

    
        public  RolesDto Role { get; set; }
    
        public  PermissionDto Permission { get; set; }
    }
}

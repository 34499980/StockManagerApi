using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
 
    public class Rules_PermissionDto
    {
      
        public int IdRule { get; set; }
        public int IdPermission {get;set;}
        public int Read { get; set; }
        public int Write { get; set; }

    
        public  RulesDto Rule { get; set; }
    
        public  PermissionDto Permission { get; set; }
    }
}

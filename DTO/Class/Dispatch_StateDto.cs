﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.Class
{
  
    public class Dispatch_StateDto : StateBaseDto
    {
     
        public int ID { get; set; }
        public string Description { get; set; }
    }
}

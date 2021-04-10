﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace DTO.Class
{
    
    public class UserDto
    {
       
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime DateAdmission { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int IdOffice { get; set; }
        public int IdRole { get; set; }
        public string File { get; set; }
        public bool Active { get; set; }
        public int IdCountry { get; set; }
        public string token { get; set; }



        public CountryDto Country { get; set; }

        public  OfficeDto Office { get; set; }
       
        public  RolesDto Role { get; set; }
    }
}

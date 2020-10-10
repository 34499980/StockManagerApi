﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    [Table("DISPATCH", Schema = "dbo")]
    public class Dispatch
    {

        [Key]
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public int IdUserOrigin { get; set; }
        public int? IdUserDestiny { get; set; }
        public int Origin { get; set; }
        public int Destiny { get; set; }
        public int IdState { get; set; }
        public DateTime? DateDispatched { get; set; }
        public DateTime? DateRecived { get; set; }
        public int? Unity { get; set; }


        [ForeignKey("IdUserOrigin")]
        public virtual User UsuarioOrigin { get; set; }
        [ForeignKey("IdUserDestiny")]
        public virtual User UsuarioDestiny { get; set; }
        [NotMapped]
        public virtual Sucursal SucOrigin { get; set; }
        [NotMapped]
        public virtual Sucursal SucDestiny { get; set; }
        [ForeignKey("IdState")]
        public virtual Dispatch_State State { get; set; }
        [NotMapped]
        public  ICollection<Stock> Stock { get; set; }       
        public virtual ICollection<Dispatch_Stock> Dispatch_stock { get; set; }
        public virtual string Code
        {
            get { return ID.ToString().PadLeft(10,'0'); }
           
        }

    }
}
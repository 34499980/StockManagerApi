//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockmanagerApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISPATCH
    {
        public int ID { get; set; }
        public System.DateTime DateCreate { get; set; }
        public int IdUser { get; set; }
        public int Origin { get; set; }
        public int Destiny { get; set; }
        public int IdState { get; set; }
        public int DateDispatched { get; set; }
        public int DateRecived { get; set; }
        public int Unity { get; set; }
    
        public virtual DISPATCH_STATE DISPATCH_STATE { get; set; }
        public virtual DISPATCH_STATE DISPATCH_STATE1 { get; set; }
    }
}

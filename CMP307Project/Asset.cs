//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMP307Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset
    {
        public int AssID { get; set; }
        public string SystemName { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public string Notes { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}

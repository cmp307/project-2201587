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
    
    public partial class Link
    {
        public int AssID { get; set; }
        public int SoftID { get; set; }
        public System.DateTime Date { get; set; }
        public bool Active { get; set; }
    
        public virtual Software Software { get; set; }
        public virtual Asset Asset { get; set; }
    }
}

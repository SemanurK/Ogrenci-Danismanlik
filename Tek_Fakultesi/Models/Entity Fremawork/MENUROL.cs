//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tek_Fakultesi.Models.Entity_Fremawork
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENUROL
    {
        public int ID { get; set; }
        public Nullable<int> ROLID { get; set; }
        public Nullable<int> MENUID { get; set; }
    
        public virtual MENU MENU { get; set; }
        public virtual MENU MENU1 { get; set; }
        public virtual ROL ROL { get; set; }
    }
}

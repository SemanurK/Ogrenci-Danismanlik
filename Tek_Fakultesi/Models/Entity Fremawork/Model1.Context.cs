﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FAKULTEEntities1 : DbContext
    {
        public FAKULTEEntities1()
            : base("name=FAKULTEEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BIRIMLER> BIRIMLER { get; set; }
        public virtual DbSet<DANISMAN_GOREVLENDİRME> DANISMAN_GOREVLENDİRME { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<MENUROL> MENUROL { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<DANISMAN> DANISMAN { get; set; }
        public virtual DbSet<OGR_DANISMAN> OGR_DANISMAN { get; set; }
        public virtual DbSet<OGRENCİ> OGRENCİ { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyIntranetPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IntraPortalEntities1 : DbContext
    {
        public IntraPortalEntities1()
            : base("name=IntraPortalEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CMS_Role> CMS_Role { get; set; }
        public virtual DbSet<CMS_User> CMS_User { get; set; }
        public virtual DbSet<CMS_UserRole> CMS_UserRole { get; set; }
    }
}

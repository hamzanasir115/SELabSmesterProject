﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UET_CSE.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UETCSEDbEntities : DbContext
    {
        public UETCSEDbEntities()
            : base("name=UETCSEDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddAchievement> AddAchievements { get; set; }
        public virtual DbSet<AddEvent> AddEvents { get; set; }
        public virtual DbSet<AddFaculty> AddFaculties { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Registered_Student> Registered_Student { get; set; }
    }
}

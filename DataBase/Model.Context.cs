﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Writer> Writers { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<WrittenPublication> WrittenPublications { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAMStock.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SAMStockEntities : DbContext
    {
        public SAMStockEntities()
            : base("name=SAMStockEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentsOfPedals> ComponentsOfPedals { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<Pedal> Pedals { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
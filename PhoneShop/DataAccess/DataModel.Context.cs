﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneShop.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhoneShopdbEntities : DbContext
    {
        public PhoneShopdbEntities()
            : base("name=PhoneShopdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<NewItem> NewItems { get; set; }
        public DbSet<PhoneBrand> PhoneBrands { get; set; }
        public DbSet<PhoneModel> PhoneModels { get; set; }
        public DbSet<Repare> Repares { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}

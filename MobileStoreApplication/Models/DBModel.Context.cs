﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileStoreApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_DisplayImage> Tbl_DisplayImage { get; set; }
        public virtual DbSet<Tbl_LoginAndRegister> Tbl_LoginAndRegister { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
    
        public virtual ObjectResult<GetBySearch_Result> GetBySearch(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBySearch_Result>("GetBySearch", searchParameter);
        }
    
        public virtual ObjectResult<Dropdown_Result> Dropdown(string ordernumber)
        {
            var ordernumberParameter = ordernumber != null ?
                new ObjectParameter("ordernumber", ordernumber) :
                new ObjectParameter("ordernumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Dropdown_Result>("Dropdown", ordernumberParameter);
        }
    
        public virtual int CancelOrder(string ordernumber)
        {
            var ordernumberParameter = ordernumber != null ?
                new ObjectParameter("ordernumber", ordernumber) :
                new ObjectParameter("ordernumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CancelOrder", ordernumberParameter);
        }
    
        public virtual int cancelOorder(string ordernumber)
        {
            var ordernumberParameter = ordernumber != null ?
                new ObjectParameter("ordernumber", ordernumber) :
                new ObjectParameter("ordernumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cancelOorder", ordernumberParameter);
        }
    
        public virtual int cancelorders(string ordernumber)
        {
            var ordernumberParameter = ordernumber != null ?
                new ObjectParameter("ordernumber", ordernumber) :
                new ObjectParameter("ordernumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cancelorders", ordernumberParameter);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoffeeCrmApp.DAL.Models;

namespace CoffeeCrmApp.DAL
{
    public class CoffeeCrmDbContext : IdentityDbContext 
    {
        public CoffeeCrmDbContext() { }
        public CoffeeCrmDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }
        public virtual DbSet<SalesHistory> SalesHistories { get; set; }
        public virtual DbSet<SalesHistoryItem> SalesHistoryItems { get; set; }

    }
}

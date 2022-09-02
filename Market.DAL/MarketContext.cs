using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.DAL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

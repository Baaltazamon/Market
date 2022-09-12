using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Market.DAL
{
    public class MarketContext : IdentityDbContext<User>
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

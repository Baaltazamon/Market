using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(MarketContext context)
        {
            context.Database.EnsureCreated();
            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }
            var sections = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Sport",
                    Order = 0,
                    ParentId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Nike",
                    Order = 0,
                    ParentId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Adidas",
                    Order = 1,
                    ParentId = 1
                },
                new Category
                {
                    Id = 4,
                    Name = "Reebok",
                    Order = 4,
                    ParentId = 1
                },
                new Category
                {
                    Id = 5,
                    Name = "Daily",
                    Order = 0,
                    ParentId = null
                },
                new Category
                {
                    Id = 6,
                    Name = "Levis",
                    Order = 0,
                    ParentId = 5
                },
                new Category
                {
                    Id = 7,
                    Name = "Shoes",
                    Order = 0,
                    ParentId = null
                }
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Categories.Add(section);
                }

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Category] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Category] OFF");
                trans.Commit();
            }
            var brands = new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "Nike",
                    Order = 0
                },
                new Brand
                {
                    Id = 2,
                    Name = "Adidas",
                    Order = 0
                },
                new Brand
                {
                    Id = 3,
                    Name = "Reebok",
                    Order = 0
                },
                new Brand
                {
                    Id = 4,
                    Name = "Levis",
                    Order = 0
                }
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var brand in brands)
                {
                    context.Brands.Add(brand);
                }

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brand] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brand] OFF");
                trans.Commit();
            }
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Футболка",
                    BrandId = 1,
                    CategoryId = 1,
                    ImageUrl = "product12.jpg",
                    Price = 800,
                    Order = 3
                },
                new Product
                {
                    Id = 2,
                    Name = "Джинсы",
                    BrandId = 2,
                    CategoryId = 2,
                    ImageUrl = "product11.jpg",
                    Price = 1800,
                    Order = 3
                },
                new Product
                {
                    Id = 3,
                    Name = "Топ",
                    BrandId = 2,
                    CategoryId = 3,
                    ImageUrl = "product10.jpg",
                    Price = 750,
                    Order = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Платье",
                    BrandId = 3,
                    CategoryId = 4,
                    ImageUrl = "product9.jpg",
                    Price = 3500,
                    Order = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "Платье зайчье",
                    BrandId = 3,
                    CategoryId = 5,
                    ImageUrl = "product8.jpg",
                    Price = 7200,
                    Order = 3
                },
                new Product
                {
                    Id = 6,
                    Name = "Платье белое",
                    BrandId = 4,
                    CategoryId = 6,
                    ImageUrl = "product7.jpg",
                    Price = 4500,
                    Order = 3
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Product] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Product] OFF");
                trans.Commit();
            }

        }
    }
}

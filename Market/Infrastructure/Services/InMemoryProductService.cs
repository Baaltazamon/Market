using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain;
using Market.Domain.Entities;
using Market.Infrastructure.Interfaces;

namespace Market.Infrastructure.Services
{
    public class InMemoryProductService: IProductService
    {
        private readonly List<Category> _categories;
        private readonly List<Brand> _brands;
        private readonly List<Product> _products;

        public InMemoryProductService()
        {
            _categories = new List<Category>
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

            _brands = new List<Brand>
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

            _products = new List<Product>
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
        }
        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var prod = _products;
            if (filter.CategoryId.HasValue)
            {
                prod = prod.Where(c => c.CategoryId == filter.CategoryId).ToList();
            }
            if (filter.BrandId.HasValue)
            {
                prod = prod.Where(c =>c.BrandId.HasValue && c.BrandId == filter.BrandId.Value).ToList();
            }

            

            return prod;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.DAL;
using Market.Domain;
using Market.Domain.Entities;
using Market.Infrastructure.Interfaces;

namespace Market.Infrastructure.Services
{
    public class SqlProductService : IProductService
    {
        private readonly MarketContext _context;

        public SqlProductService(MarketContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.AsQueryable();
            if (filter.BrandId.HasValue)
            {
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            }

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId));
            }

            return query.ToList();

        }
    }
}

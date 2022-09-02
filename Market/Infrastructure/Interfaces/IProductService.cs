using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain;
using Market.Domain.Entities;

namespace Market.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain;
using Market.Infrastructure.Interfaces;
using Market.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Market.ViewComponents
{
    public class BrandsViewComponent: ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync()
#pragma warning restore 1998
        {
            var brands = GetBrands();
            return View(brands);
        }

        private List<BrandViewModel> GetBrands()
        {
            var brands = _productService.GetBrands();
            var prod = _productService.GetProducts(new ProductFilter());
            var listBrands = new List<BrandViewModel>();
            foreach (var brand in brands)
            {
                listBrands.Add(new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Order = brand.Order,
                    Count = prod.Count(c=> c.BrandId == brand.Id)
                });

            }

            return listBrands;
        }
    }
}

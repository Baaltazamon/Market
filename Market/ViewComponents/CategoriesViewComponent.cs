using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Infrastructure.Interfaces;
using Market.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Market.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public CategoriesViewComponent(IProductService productService)
        {
            _productService = productService;
        }
#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync()
#pragma warning restore 1998
        {
            var categories = GetCategories();
            return View(categories);
        }

        private List<CategoryViewModel> GetCategories()
        {
            var categories = _productService.GetCategories();
            var parentSections = categories.Where(c => !c.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();
            foreach (var VARIABLE in parentSections)
            {
                parentCategories.Add(new CategoryViewModel
                {
                    Id = VARIABLE.Id,
                    Name = VARIABLE.Name,
                    Order = VARIABLE.Order,
                    ParentCategory = null
                });
            }

            foreach (var categoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(c => c.ParentId == categoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    categoryViewModel.ChildCategory.Add(new CategoryViewModel
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = categoryViewModel
                    });
                }

                categoryViewModel.ChildCategory = categoryViewModel.ChildCategory.OrderBy(c => c.Id).ToList();
            }

            parentCategories = parentCategories.OrderBy(c => c.Id).ToList();
            return parentCategories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.ViewModels
{
    public class CategoryViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public List<CategoryViewModel> ChildCategory { get; set; }

        public CategoryViewModel ParentCategory { get; set; }
        public CategoryViewModel()
        {
            ChildCategory = new List<CategoryViewModel>();
        }
    }
}

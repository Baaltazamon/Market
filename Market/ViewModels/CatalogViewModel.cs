using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.ViewModels
{
    public class CatalogViewModel
    { 
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

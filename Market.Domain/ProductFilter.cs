using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain
{
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}

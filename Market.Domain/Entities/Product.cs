using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Market.Domain.Entities.Base;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.Domain.Entities
{
    [Table("Product")]
    public class Product: NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Market.Domain.Entities.Base;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.Domain.Entities
{
    [Table("Category")]
    public class Category: NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
    }
}

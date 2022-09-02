using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Market.Domain.Entities.Base;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.Domain.Entities
{
    [Table("Brand")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public virtual  ICollection<Product> Products { get; set; }
    }
}

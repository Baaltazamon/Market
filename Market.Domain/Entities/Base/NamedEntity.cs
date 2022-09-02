using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain.Entities.Base.Interfaces;

namespace Market.Domain.Entities.Base
{
    public abstract class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

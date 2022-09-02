using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain.Entities.Base.Interfaces
{
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}

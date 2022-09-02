using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity
    {
        int Id { get; set; }
        string Name { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain.Entities.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public int Count { get; set; }

        public BrandViewModel()
        {
            
        }
    }
}

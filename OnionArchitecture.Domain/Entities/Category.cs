using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Entities
{
    public  class Category:BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; } = [];
    }
}

using OnionArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}

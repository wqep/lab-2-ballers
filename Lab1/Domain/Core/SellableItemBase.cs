using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    abstract class SellableItemBase 
    {
        public string Name { get; }
        public decimal BasePrice { get; set; } = 600;
        public SellableItemBase (string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }

    }
}

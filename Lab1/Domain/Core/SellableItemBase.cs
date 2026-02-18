<<<<<<< HEAD
﻿namespace Lab1.Domain.Core
=======
﻿namespace Lab1.Domain.Core;

public abstract class SellableItemBase
>>>>>>> d61e295 (Tests.)
{
    public string Name { get; }
    public decimal BasePrice { get; set; }
    public SellableItemBase(string name, decimal basePrice)
    {
<<<<<<< HEAD
        public string Name { get; }
        public decimal BasePrice { get; set; }
        public SellableItemBase (string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
=======
        Name = name;
        BasePrice = basePrice;
>>>>>>> d61e295 (Tests.)
    }
    public SellableItemBase(string name)
    {
        Name = name;
    }

}
namespace Lab1.Domain.Core
{
    public abstract class SellableItemBase 
    {
        public string Name { get; }
        public decimal BasePrice { get; set; }
        public SellableItemBase (string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
    }
}

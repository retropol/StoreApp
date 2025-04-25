using DataLayer.Concrete;

namespace WebLayer.Models
{
    public class Card
    {
        public List<CardItem> CardItems { get; set; } = new();
        
        public virtual void AddItem(Product product, int Quantity)
        {
            var item = CardItems.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
            {
                item.Quantity += Quantity;
            }
            else
            {
                CardItems.Add(new CardItem { Product = product, Quantity = Quantity });
            }
        }

        public virtual void RemoveItem(Product product)
        {
            var item = CardItems.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
            {
                CardItems.Remove(item);
            }
        }

        public virtual decimal CalculateTotalPrice()
        {
            return CardItems.Sum(x => x.Product.Price * x.Quantity);
        }

        public virtual void ClearCard()
        {
            CardItems.Clear();
        }
    }

    public class CardItem
    {
        public int CardItemId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}

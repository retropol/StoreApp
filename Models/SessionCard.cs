using DataLayer.Concrete;
using WebLayer.Helpers;

namespace WebLayer.Models
{
    public class SessionCard : Card
    {
       
        public static Card GetCardFromSession(HttpContext context)
        {
            var card = context.Session.GetObject<Card>("Card");
            if (card == null)
            {
                card = new SessionCard();
                context.Session.SetObject("Card", card);
            }
            return card;
        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);

             
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
        }

        public override decimal CalculateTotalPrice()
        {
            return base.CalculateTotalPrice();
        }

        public override void ClearCard()
        {
            base.ClearCard();
        }
    }
}

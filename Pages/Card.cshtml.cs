using DataLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLayer.Models;
using System.Text.Json;
using WebLayer.Helpers;
namespace WebLayer.Pages
{
    public class CardModel : PageModel
    {
        public Card? Card { get; set; }

        private IStoreRepository _storeRepository;

        public CardModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void OnGet()
        {
            Card = HttpContext.Session.GetObject<Card>("Card") ?? new Card();
        }
        public IActionResult OnPost(int productId)
        {
            var product = _storeRepository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Card = HttpContext.Session.GetObject<Card>("Card") ?? new Card();
                Card.AddItem(product,1);
                HttpContext.Session.SetObject("Card", Card);
            }
            return RedirectToPage();
        }
        public IActionResult OnPostRemove(int productId)
        {
            var product = _storeRepository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Card = HttpContext.Session.GetObject<Card>("Card") ?? new Card();
                Card.RemoveItem(product);
                HttpContext.Session.SetObject("Card", Card);
            }
            return RedirectToPage("/Card");
        }
    }
}

using AutoMapper;
using DataLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 3;

        private IStoreRepository _storeRepository;

        private IMapper _mapper;
        public HomeController(IStoreRepository storeRepository,IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public IActionResult Index(string category,int page =1) {

           


            return View(new ProductListViewModel
            {
                Products = _storeRepository.GetProductsByCategory(category, page, pageSize)
                .Select(product => _mapper.Map<ProductViewModel>(product)),

                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = _storeRepository.GetProductCount(category),
                    CurrentPage = page
                }
            }); 
                
             }

    }

      
    
}

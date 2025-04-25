using DataLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;

namespace WebLayer.Components;

public class CategoriesListViewComponent : ViewComponent
{
    private IStoreRepository _storeRepository;

    public CategoriesListViewComponent(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }


    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(_storeRepository.Categories.Select(c=> new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Url = c.Url,


        }).ToList());
    }
}



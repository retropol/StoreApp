using AutoMapper;
using DataLayer.Concrete;
namespace WebLayer.Models
{
    public class MapperProfile:Profile
    {

        public MapperProfile()
        {
         
            CreateMap<Product, ProductViewModel>();
        }
       
    }
}

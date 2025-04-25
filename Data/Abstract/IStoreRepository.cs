using DataLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }

        void CreateProduct(Product entity);

        int GetProductCount(string category);
        
        IEnumerable<Product> GetProductsByCategory(string category, int page, int pageSize);

    }
}

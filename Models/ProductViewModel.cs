﻿namespace WebLayer.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public class  ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();

        public PageInfo PageInfo { get; set; } = new();
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
        public int CurrentPage { get; set; }
    }
}


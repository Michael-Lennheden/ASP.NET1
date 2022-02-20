﻿namespace ASP.NET_Core_Mvc_Project_WebApi.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductModel(int id, string name, string description, decimal price, int categoryId, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
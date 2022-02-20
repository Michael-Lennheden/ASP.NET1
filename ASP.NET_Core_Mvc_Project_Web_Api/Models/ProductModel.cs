using ASP.NET_Core_Mvc_Project_Web_Api.Models.Entities;

namespace ASP.NET_Core_Mvc_Project_Web_Api.Models
{
    public class ProductModel
    {
        public ProductModel(int id, int categoryId, string name, string description, decimal price)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductModel(int id, CategoryEntity categoryEntity, int categoryId, string name, string description, decimal price)
        {
            Id = id;
            CategoryEntity = categoryEntity;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

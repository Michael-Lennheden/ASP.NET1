using ASP.NET_Core_Mvc_Project_Web_Api.Models.Entities;

namespace ASP.NET_Core_Mvc_Project_Web_Api.Models
{
    public class CreateProductModel
    {
        public CreateProductModel(CategoryEntity categoryEntity, string name, string description, decimal price)
        {
            CategoryEntity.CategoryId = categoryEntity.CategoryId;
            Name = name;
            Description = description;
            Price = price;
        }

        public CategoryEntity CategoryEntity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

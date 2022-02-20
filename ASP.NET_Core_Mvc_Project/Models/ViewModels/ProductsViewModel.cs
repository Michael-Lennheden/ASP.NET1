using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Mvc_Project.Models.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {

        }

        public ProductsViewModel(string name, string description, decimal price, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        [Display(Name = "Artikelnummer")]
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Pris")]
        public decimal Price { get; set; }

        [Display(Name = "Kategori")]
        public string Category { get; set; }

        public int CategoryId { get; set; }
    }
}

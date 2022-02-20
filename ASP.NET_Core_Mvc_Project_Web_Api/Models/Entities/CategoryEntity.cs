using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Mvc_Project_Web_Api.Models.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity(string categoryName)
        {
            CategoryName = categoryName;
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}

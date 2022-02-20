using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Mvc_Project_Web_Api.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity(int categoryEntity, string name, string description, decimal price)
        {
            CategoryEntity.CategoryId = categoryEntity;
            Name = name;
            Description = description;
            Price = price;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public CategoryEntity CategoryEntity { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}

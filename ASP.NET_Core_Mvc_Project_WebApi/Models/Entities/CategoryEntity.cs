using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Mvc_Project_WebApi.Models.Entities
{
    
    [Index(nameof(Name), IsUnique = true)]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity>? Products { get; }
    }
}

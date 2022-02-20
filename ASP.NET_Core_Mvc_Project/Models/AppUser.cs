using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Mvc_Project.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
    }
}

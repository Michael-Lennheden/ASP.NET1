using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Mvc_Project.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [StringLength(100, ErrorMessage = "Förnamnet måste bestå av minst 2 tecken", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [StringLength(100, ErrorMessage = "Efternamnet måste bestå av minst 2 tecken", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [StringLength(100, ErrorMessage = "E-postadressen måste vara giltig", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [StringLength(100, ErrorMessage = "Lösenordet måste bestå av minst 8 tecken")]
        public string Password { get; set; }

        [Display(Name = "Bekräfta lösenord")]
        [Required(ErrorMessage = "Du måste bekräfta lösenordet")]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden stämmer inte överens")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Domain
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

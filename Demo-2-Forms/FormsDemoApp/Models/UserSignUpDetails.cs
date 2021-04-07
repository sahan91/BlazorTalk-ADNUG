using System.ComponentModel.DataAnnotations;

namespace FormsDemoApp.Models
{
    public class UserSignUpDetails
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [CompareProperty("Email", 
            ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
    }
}

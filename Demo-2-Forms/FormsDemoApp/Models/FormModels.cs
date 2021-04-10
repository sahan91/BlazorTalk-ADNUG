using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace FormsDemoApp.Models
{
    public class AnnotationsFormModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Confirm email")]
        [CompareProperty("Email", 
            ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
    }


    public class FluentFormModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string Password { get; set; }
    }



    public class FluentFormModelValidator : AbstractValidator<FluentFormModel>
    {
        public FluentFormModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("You must select a country");
                
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.ConfirmEmail)
                .NotEmpty()
                .Equal(x => x.Email)
                .WithMessage("Confirm email and email do not match");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20)
                .Must(IsValidPassword)
                .WithMessage("Your password can only contain letters and numbers, and must not contain spaces.");
        }

        private bool IsValidPassword(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            return Regex.IsMatch(word, "^[^\\s]+$");
        }
        
    }
}

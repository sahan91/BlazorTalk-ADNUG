using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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


	public class UserSignUpDetailsValidator : AbstractValidator<UserSignUpDetails>
	{
		public UserSignUpDetailsValidator()
		{
			RuleFor(x => x.Name)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty()
				.MustAsync(IsNotPalindrome).WithMessage("Your name cannot be a palindrome");
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
		}

		private async Task<bool> IsNotPalindrome(string word, CancellationToken cancellationToken)
		{
			await Task.Delay(1000, cancellationToken);

            var reversedWord = new string(word.Reverse().ToArray());

            var areSame = word.Equals(reversedWord);

            return !areSame;
		}
        
    }
}

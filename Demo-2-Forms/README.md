# Forms and Validation

This demo contains 2 forms.

## /Home

The home page is used to host an [EditForm](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0) that uses data annotations to define validation logic.

The model is used to provide a new user registration and has the following validation constraints defined using attributes.

```csharp
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
```

All validation is defined using the attributes and the `EditForm` uses the convenient [OnValidSubmit](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform.onvalidsubmit?view=aspnetcore-5.0#Microsoft_AspNetCore_Components_Forms_EditForm_OnValidSubmit) event to handle the form submission.

## /Advanced

In the advanced demo, we utilize the [PeterLeslieMorris.Blazor.FluentValidation](https://github.com/mrpmorris/blazor-validation) package to wire-up validation logic using [FluentValidation](https://fluentvalidation.net/) rules.

Note: there is [another Blazor.FluentValidation component that is worth checking out](https://github.com/ryanelian/FluentValidation.Blazor).

In this example, we utilize the data annotations for simple validation but layer-in some advanced business logic using FluentValidation.

```csharp
public class UserSignUpDetailsValidator : AbstractValidator<UserSignUpDetails>
{
    public UserSignUpDetailsValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .Must(NotBePalindrome).WithMessage("Your name cannot be a palindrome");

        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }

    private bool NotBePalindrome(string word)
    {
        var reversedWord = new string(word.Reverse().ToArray());
        var areSame = word.Equals(reversedWord);

        return !areSame;
    }

}
```

The beauty of this example is that you can leverage the same rich business rules in the client and on the backend without having to duplicate code or logic.

## Further Reading

- [Creating custom validator components](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#validator-components)

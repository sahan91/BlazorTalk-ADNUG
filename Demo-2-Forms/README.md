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

In the advanced demo, we utilize the [PeterLeslieMorris.Blazor.FluentValidation](https://www.nuget.org/packages/PeterLeslieMorris.Blazor.FluentValidation/) package to wire-up validation logic using [FluentValidation](https://fluentvalidation.net/) rules.

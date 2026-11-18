using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dotnet_11_Changes.AsyncValidation;

internal record RegisterUser([Required, UniqueEmail] string Email, [Required] string Password);

public sealed class UniqueEmailAttribute : AsyncValidationAttribute
{
    private readonly HashSet<string> _existingEmails = ["test@gmail.com"];

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }

    protected override async Task<ValidationResult?> IsValidAsync(object? value, ValidationContext validationContext, CancellationToken cancellationToken)
    {
        if (value is not string email)
        {
            return new ValidationResult("Invalid email format.");
        }

        // Simulate an asynchronous check for email uniqueness
        await Task.Delay(100, cancellationToken); // Simulating async operation

        if (_existingEmails.Contains(email))
        {
            return new ValidationResult("Email is already in use.");
        }

        return null;
    }
}

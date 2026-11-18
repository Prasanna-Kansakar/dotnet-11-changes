using System.ComponentModel.DataAnnotations;

namespace Dotnet_11_Changes.AsyncValidation;

public record WithdrawAmount(string UserId, decimal Amount) : IAsyncValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }

    public async IAsyncEnumerable<ValidationResult> ValidateAsync(ValidationContext validationContext, CancellationToken cancellationToken = default)
    {
        if (Amount <= 0)
        {
            yield return new ValidationResult("Amount must be greater than zero.", [nameof(Amount)]);
        }

        await Task.Delay(100, cancellationToken); // Simulating async operation
        var withdrawlimit = 1000;
        
        if (withdrawlimit < Amount)
        {
            yield return new ValidationResult("Insufficient balance.", [nameof(Amount)]);
        }
    }
}
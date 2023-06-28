using FluentValidation.Results;

namespace Modules.Csv.Abstractions.Extensions;

public static class ValidationResultExtensions
{
    public static void AddErrors(this List<string> errors, ValidationResult validationResult)
    {
        errors.AddRange(validationResult.Errors.Select(result => $"{result.ErrorMessage}"));
    }
}
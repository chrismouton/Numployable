namespace Numployable.Application.Exceptions;

using System.Linq;

using FluentValidation.Results;

public class ValidationException : ApplicationException
{
    public ValidationException(ValidationResult validationResult)
    {
        Errors = new List<string>(validationResult.Errors.Count);
        Errors = validationResult.Errors.Select(item => item.ErrorMessage).ToList();
    }

    public IList<string> Errors { get; private set; }
}
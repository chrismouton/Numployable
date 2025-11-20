using FluentValidation.Results;

namespace Numployable.Application.Exceptions;

public abstract class ValidationException : ApplicationException
{
    protected ValidationException(ValidationResult validationResult)
    {
        Errors = new List<string>(validationResult.Errors.Count);
        Errors = validationResult.Errors.Select(item => item.ErrorMessage).ToList();
    }

    public IList<string> Errors { get; private set; }
}
namespace Numploy.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Numploy.Application.DTOs.Common;
using Numploy.Application.Persistence.Contracts;

public abstract class BaseJobApplicationDtoValidator<T> : AbstractValidator<T>
    where T : BaseDto
{
    public BaseJobApplicationDtoValidator(IJobApplicationRepository repository)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async(id, token) => 
            {
                bool exists = await repository.Exists(id);
                return !exists;
            }).WithMessage("{PropertyName} does not exists in the repository.");
    }
}

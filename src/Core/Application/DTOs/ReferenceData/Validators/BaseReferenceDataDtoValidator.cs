namespace Numployable.Application.DTOs.ReferenceData.Validators;

using FluentValidation;
using Persistence.Contracts;

public abstract class BaseReferenceDataDtoValidator<T> : AbstractValidator<BaseReferenceDataDto>
    where T : BaseReferenceDataDto
{
    public BaseReferenceDataDtoValidator(IReferenceDataRepository<T> repository)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    bool exists = await repository.Exists(id);
                    return !exists;
                }
            )
            .WithMessage("{PropertyName} does not exists in the repository.");
        
        RuleFor(p => p.Description).NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
    }
}

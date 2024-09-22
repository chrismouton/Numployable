namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using FluentValidation;
using Persistence.Contracts;

public abstract class BaseInfrastructureDataDtoValidator<T> : AbstractValidator<BaseInfrastructureDataDto>
    where T : BaseInfrastructureDataDto
{
    public BaseInfrastructureDataDtoValidator(IInfrastructureDataRepository<T> repository)
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

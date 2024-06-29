namespace Numploy.Application.DTOs.NextActions.Validators;

using FluentValidation;
using Numploy.Application.Persistence.Contracts;

public class UpdateNextActionsDtoValidator : AbstractValidator<CreateNextActionDto>
{
    public UpdateNextActionsDtoValidator(INextActionRepository repository)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async(id, token) => 
            {
                bool exists = await repository.Exists(id);
                return !exists;
            }).WithMessage("{PropertyName} does not exists in the repository.");

        Include(new CreateNextActionsDtoValidator());
    }
}

namespace Numploy.Application.DTOs.NextActions.Validators;

using FluentValidation;

public class CreateNextActionsDtoValidator : AbstractValidator<CreateNextActionDto>
{
    public CreateNextActionsDtoValidator()
    {
        RuleFor(p => p.NextActionType).NotNull();
        RuleFor(p => p.ActionNote)
            .NotNull()
            .NotEmpty();
        RuleFor(p => p.ActionDate).NotNull();
    }
}

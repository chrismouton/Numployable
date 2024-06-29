using FluentValidation;

namespace Numployable.Application.DTOs.JobApplications.Validators;

public class CreateJobApplicationDtoValidator : AbstractValidator<CreateJobApplicationDto>
{
    public CreateJobApplicationDtoValidator()
    {
        RuleFor(p => p.RoleName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        RuleFor(p => p.CompanyName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        RuleFor(p => p.RoleType)
            .NotNull();
        RuleFor(p => p.ApplicationDate)
            .NotNull();
        RuleFor(p => p.ApplicationStatus)
            .NotNull();
        RuleFor(p => p.ApplicationProcessStatus)
            .NotNull();
        RuleFor(p => p.ApplicationSource)
            .NotNull();
    }
}
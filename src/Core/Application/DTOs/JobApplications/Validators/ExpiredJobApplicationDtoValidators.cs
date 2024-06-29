namespace Numployable.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Numployable.Application.Persistence.Contracts;

public class ExpiredJobApplicationDtoValidator : BaseJobApplicationDtoValidator<ExpiredJobApplicationDto>
{
    public ExpiredJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ApplicationStatus).Equal(ApplicationStatus.Expired);
    }
}

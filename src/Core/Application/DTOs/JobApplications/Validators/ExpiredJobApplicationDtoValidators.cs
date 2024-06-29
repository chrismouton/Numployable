namespace Numploy.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Numploy.Application.Persistence.Contracts;

public class ExpiredJobApplicationDtoValidator : BaseJobApplicationDtoValidator<ExpiredJobApplicationDto>
{
    public ExpiredJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ApplicationStatus).Equal(ApplicationStatus.Expired);
    }
}

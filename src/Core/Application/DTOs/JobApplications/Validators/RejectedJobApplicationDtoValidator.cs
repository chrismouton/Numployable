namespace Numploy.Application.DTOs.JobApplications.Validators;

using FluentValidation;

using Numploy.Application.Persistence.Contracts;

public class RejectedJobApplicationDtoValidator : BaseJobApplicationDtoValidator<RejectedJobApplicationDto>
{
    public RejectedJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ApplicationStatus).Equal(ApplicationStatus.Closed);
        RuleFor(p => p.ApplicationProcessStatus).Equal(ApplicationProcessStatus.Rejected);
    }
}

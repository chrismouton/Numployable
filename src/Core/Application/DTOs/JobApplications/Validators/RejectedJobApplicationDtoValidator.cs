namespace Numployable.Application.DTOs.JobApplications.Validators;

using FluentValidation;

using Numployable.Application.Persistence.Contracts;

public class RejectedJobApplicationDtoValidator : BaseJobApplicationDtoValidator<RejectedJobApplicationDto>
{
    public RejectedJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ApplicationStatus).Equal(ApplicationStatus.Closed);
        RuleFor(p => p.ApplicationProcessStatus).Equal(ApplicationProcessStatus.Rejected);
    }
}

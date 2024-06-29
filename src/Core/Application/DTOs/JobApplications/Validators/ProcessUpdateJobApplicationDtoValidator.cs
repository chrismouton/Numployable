namespace Numploy.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Numploy.Application.Persistence.Contracts;

public class ProcessUpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<ProcessUpdateJobApplicationDto>
{
    public ProcessUpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ApplicationProcessStatus).NotNull();
    }
}

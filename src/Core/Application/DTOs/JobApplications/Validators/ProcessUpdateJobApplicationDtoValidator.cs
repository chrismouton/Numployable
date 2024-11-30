namespace Numployable.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Persistence.Contracts;

public class ProcessUpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<ProcessUpdateJobApplicationDto>
{
    public ProcessUpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ProcessStatus).NotNull();
    }
}

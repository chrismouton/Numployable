using FluentValidation;
using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.JobApplications.Validators;

public class ProcessUpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<ProcessUpdateJobApplicationDto>
{
    public ProcessUpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
        RuleFor(p => p.ProcessStatus).NotNull();
    }
}

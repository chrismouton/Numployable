namespace Numployable.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Persistence.Contracts;

public class UpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<UpdateJobApplicationDto>
{
    public UpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
       Include(new CreateJobApplicationDtoValidator());
    }
}

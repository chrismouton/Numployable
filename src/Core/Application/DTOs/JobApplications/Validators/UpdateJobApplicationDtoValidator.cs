namespace Numploy.Application.DTOs.JobApplications.Validators;

using FluentValidation;
using Numploy.Application.Persistence.Contracts;

public class UpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<UpdateJobApplicationDto>
{
    public UpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
       Include(new CreateJobApplicationDtoValidator());
    }
}

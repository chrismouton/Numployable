using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.JobApplications.Validators;

public class UpdateJobApplicationDtoValidator : BaseJobApplicationDtoValidator<UpdateJobApplicationDto>
{
    public UpdateJobApplicationDtoValidator(IJobApplicationRepository repository)
        : base(repository)
    {
       Include(new CreateJobApplicationDtoValidator());
    }
}

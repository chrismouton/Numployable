using MediatR;

using Numployable.Application.DTOs.JobApplications.Validators;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<CreateJobApplicationCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateJobApplicationDto == null)
            throw new ArgumentNullException(nameof(request));

        BaseCommandResponse response = new();

        var validator = new CreateJobApplicationDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateJobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for creation failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            JobApplication jobApplication = await jobApplicationRepository.Add(request.CreateJobApplicationDto.ToJobApplication());

            response.Success = true;
            response.Message = "Creation success";
            response.Id = jobApplication.Id;
        }

        return response;
    }
}
using FluentValidation.Results;
using Mediator;
using Numployable.Application.DTOs.JobApplications.Validators;
using Numployable.Application.Exceptions;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class UpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
    : ICommandHandler<UpdateJobApplicationCommand, BaseCommandResponse>
{
    public async ValueTask<BaseCommandResponse> Handle(UpdateJobApplicationCommand request,
        CancellationToken cancellationToken)
    {
        JobApplication? jobApplication = await jobApplicationRepository.Get(request.Id);

        if (jobApplication == null)
            throw new NotFoundException(nameof(jobApplication), request.Id);

        BaseCommandResponse response = new();

        UpdateJobApplicationDtoValidator validator = new(jobApplicationRepository);
        ValidationResult? validationResult =
            await validator.ValidateAsync(request.UpdateJobApplication, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for update failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            await jobApplicationRepository.Update(request.UpdateJobApplication.ToJobApplication());

            response.Success = true;
            response.Message = "Update successful";
            response.Id = jobApplication.Id;
        }

        return response;
    }
}
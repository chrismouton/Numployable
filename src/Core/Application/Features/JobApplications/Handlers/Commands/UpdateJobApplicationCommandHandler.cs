namespace Numploy.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numploy.Application.Features.JobApplications.Requests.Commands;
using Numploy.Application.Persistence.Contracts;
using Numploy.Application.DTOs.JobApplications.Validators;
using Numploy.Application.Exceptions;
using Numploy.Application.Responses;
using System.Runtime.CompilerServices;
using Numploy.Domain;

public class UpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    : IRequestHandler<UpdateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var jobApplication = await _jobApplicationRepository.Get(request.Id);

        if (jobApplication == null)
            throw new NotFoundException(nameof(jobApplication), request.Id);

        BaseCommandResponse response = new();

        if (request.UpdateJobApplicationDto != null)
        {
            await UpdateJobApplication(request, jobApplication, response, cancellationToken);
        }
        if (request.ExpiredJobApplicationDto != null)
        {
            await ExpiredJobApplication(request, jobApplication, response, cancellationToken);
        }
        else if (request.ProcessUpdateJobApplicationDto != null)
        {
            await ProcessUpdateJobApplication(request, jobApplication, response, cancellationToken);
        }
        else if (request.RejectedJobApplicationDto != null)
        {
            await RejectedJobApplication(request, jobApplication, response, cancellationToken);
        }

        return response;
    }

    private async Task RejectedJobApplication(UpdateJobApplicationCommand request, JobApplication jobApplication, BaseCommandResponse response, CancellationToken cancellationToken)
    {
        RejectedJobApplicationDtoValidator validator = new(_jobApplicationRepository);
        var validationResult = await validator.ValidateAsync(request.RejectedJobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for rejected job application failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToList());
        }
        else
        {
            await _jobApplicationRepository.RejectedJobApplication(jobApplication, request.RejectedJobApplicationDto.ApplicationStatus, request.RejectedJobApplicationDto.ApplicationProcessStatus);

            response.Success = true;
            response.Message = "Successfully rejected job application.";
            response.Id = jobApplication.Id;
        }
    }

    private async Task ProcessUpdateJobApplication(UpdateJobApplicationCommand request, JobApplication jobApplication, BaseCommandResponse response, CancellationToken cancellationToken)
    {
        if (request.ProcessUpdateJobApplicationDto.ApplicationProcessStatus == null)
            throw new ArgumentNullException(nameof(request.ProcessUpdateJobApplicationDto.ApplicationProcessStatus));

        ProcessUpdateJobApplicationDtoValidator validator = new(_jobApplicationRepository);
        var validationResult = await validator.ValidateAsync(request.ProcessUpdateJobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for process update of job application failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            await _jobApplicationRepository.ProcessUpdateJobApplication(jobApplication, request.ProcessUpdateJobApplicationDto.ApplicationProcessStatus.Value);

            response.Success = true;
            response.Message = "Successfully update process status for application.";
            response.Id = jobApplication.Id;
        }
    }

    private async Task ExpiredJobApplication(UpdateJobApplicationCommand request, JobApplication jobApplication, BaseCommandResponse response, CancellationToken cancellationToken)
    {
        ExpiredJobApplicationDtoValidator validator = new(_jobApplicationRepository);
        var validationResult = await validator.ValidateAsync(request.ExpiredJobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for expired application failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            await _jobApplicationRepository.ExpireJobApplication(jobApplication, request.ExpiredJobApplicationDto.ApplicationStatus);

            response.Success = true;
            response.Message = "Job application successfully expired.";
            response.Id = jobApplication.Id;
        }
    }

    private async Task UpdateJobApplication(UpdateJobApplicationCommand request, JobApplication jobApplication, BaseCommandResponse response, CancellationToken cancellationToken)
    {
        UpdateJobApplicationDtoValidator validator = new(_jobApplicationRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateJobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for update failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            _mapper.Map(request.UpdateJobApplicationDto, jobApplication);

            await _jobApplicationRepository.Update(jobApplication);

            response.Success = true;
            response.Message = "Update successful";
            response.Id = jobApplication.Id;
        }
    }
}
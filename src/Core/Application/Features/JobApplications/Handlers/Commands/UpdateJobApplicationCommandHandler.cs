using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.JobApplications.Validators;
using Numployable.Application.Exceptions;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class UpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    : IRequestHandler<UpdateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        JobApplication jobApplication = await _jobApplicationRepository.Get(request.Id);

        if (jobApplication == null)
            throw new NotFoundException(nameof(jobApplication), request.Id);

        BaseCommandResponse response = new();

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

        return response;
    }
}
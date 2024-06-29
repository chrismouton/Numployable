namespace Numploy.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;
using Numploy.Application.DTOs.JobApplications.Validators;
using Numploy.Application.Exceptions;
using Numploy.Application.Features.JobApplications.Requests.Commands;
using Numploy.Application.Persistence.Contracts;
using Numploy.Application.Responses;
using Numploy.Domain;

public class CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    : IRequestHandler<CreateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        if (request.JobApplicationDto == null)
            throw new ArgumentNullException(nameof(request.JobApplicationDto));

        BaseCommandResponse response = new();

        var validator = new CreateJobApplicationDtoValidator();
        var validationResult = await validator.ValidateAsync(request.JobApplicationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for creation failed.";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            JobApplication jobApplication = _mapper.Map<JobApplication>(request.JobApplicationDto);
            jobApplication = await _jobApplicationRepository.Add(jobApplication);

            response.Success = true;
            response.Message = "Creation success";
            response.Id = jobApplication.Id;
        }

        return response;
    }
}
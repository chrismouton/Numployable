namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.JobApplications.Validators;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

public class CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    : IRequestHandler<CreateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateJobApplicationDto == null)
            throw new ArgumentNullException(nameof(request.CreateJobApplicationDto));

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
            JobApplication jobApplication = _mapper.Map<JobApplication>(request.CreateJobApplicationDto);
            jobApplication = await _jobApplicationRepository.Add(jobApplication);

            response.Success = true;
            response.Message = "Creation success";
            response.Id = jobApplication.Id;
        }

        return response;
    }
}
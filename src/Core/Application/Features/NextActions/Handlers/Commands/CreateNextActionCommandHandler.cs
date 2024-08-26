namespace Numployable.Application.Features.NextActions.Handlers.Commands;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.NextActions.Validators;
using Numployable.Application.Features.NextActions.Requests.Commands;
using Persistence.Contracts;
using Responses;
using Domain;

public class CreateNextActionCommandHandler(INextActionRepository nextActionRepository, IMapper mapper)
    : IRequestHandler<CreateNextActionCommand, BaseCommandResponse>
{
    private readonly INextActionRepository _nextActionRepository = nextActionRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(CreateNextActionCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateNextActionDto == null)
            throw new ArgumentNullException(nameof(request.CreateNextActionDto));

        BaseCommandResponse response = new();

        CreateNextActionsDtoValidator validator = new();
        var validationResult = await validator.ValidateAsync(request.CreateNextActionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(item => item.ErrorMessage).ToList();
        }
        else
        {
            var nextAction = _mapper.Map<NextAction>(request.CreateNextActionDto);

            nextAction = await _nextActionRepository.Add(nextAction);

            response.Success = true;
            response.Message = "Creation successful";
            response.Id = nextAction.Id;
        }

        return response;
    }
}
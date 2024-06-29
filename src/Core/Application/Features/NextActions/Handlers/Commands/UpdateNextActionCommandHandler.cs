namespace Numploy.Application.Features.NextActions.Handlers.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;
using Numploy.Application.DTOs.NextActions.Validators;
using Numploy.Application.Exceptions;
using Numploy.Application.Features.NextActions.Requests.Commands;
using Numploy.Application.Persistence.Contracts;
using Numploy.Application.Responses;

public class UpdateNextActionCommandHandler(INextActionRepository nextActionRepository, IMapper mapper)
    : IRequestHandler<UpdateNextActionCommand, BaseCommandResponse>
{
    private readonly INextActionRepository _nextActionRepository = nextActionRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(UpdateNextActionCommand request, CancellationToken cancellationToken)
    {
        if (request.UpdateNextActionDto == null)
            throw new NullReferenceException(nameof(request.UpdateNextActionDto));

        BaseCommandResponse response = new();

        UpdateNextActionsDtoValidator validator = new(_nextActionRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateNextActionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for update failed";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            var nextAction = await _nextActionRepository.Get(request.UpdateNextActionDto.Id);
            if (nextAction == null)
                throw new NotFoundException(nameof(nextAction), request.UpdateNextActionDto.Id);

            _mapper.Map(request.UpdateNextActionDto, nextAction);

            await _nextActionRepository.Update(nextAction);

            response.Success = true;
            response.Message = "Update successful";
            response.Id = request.UpdateNextActionDto.Id;
        }

        return response;
    }
}
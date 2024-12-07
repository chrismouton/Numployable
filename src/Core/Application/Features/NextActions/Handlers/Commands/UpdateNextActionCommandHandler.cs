using MediatR;

using Numployable.Application.DTOs.NextActions.Validators;
using Numployable.Application.Exceptions;
using Numployable.Application.Features.NextActions.Requests.Commands;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.NextActions.Handlers.Commands;

public class UpdateNextActionCommandHandler(INextActionRepository nextActionRepository)
    : IRequestHandler<UpdateNextActionCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(UpdateNextActionCommand request, CancellationToken cancellationToken)
    {
        if (request.UpdateNextActionDto == null)
            throw new NullReferenceException(nameof(request.UpdateNextActionDto));

        BaseCommandResponse response = new();

        UpdateNextActionsDtoValidator validator = new(nextActionRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateNextActionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Validation for update failed";
            response.Errors.AddRange(validationResult.Errors.Select(item => item.ErrorMessage).ToArray());
        }
        else
        {
            var nextAction = await nextActionRepository.Get(request.Id);
            if (nextAction == null)
                throw new NotFoundException(nameof(nextAction), request.Id);

            await nextActionRepository.Update(request.UpdateNextActionDto.ToNextAction());

            response.Success = true;
            response.Message = "Update successful";
            response.Id = request.UpdateNextActionDto.Id;
        }

        return response;
    }
}
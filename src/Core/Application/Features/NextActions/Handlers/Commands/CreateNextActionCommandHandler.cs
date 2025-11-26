using FluentValidation.Results;
using Mediator;
using Numployable.Application.DTOs.NextActions.Validators;
using Numployable.Application.Features.NextActions.Requests.Command;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.NextActions.Handlers.Commands;

public class CreateNextActionCommandHandler(INextActionRepository nextActionRepository)
    : ICommandHandler<CreateNextActionCommand, BaseCommandResponse>
{
    public async ValueTask<BaseCommandResponse> Handle(CreateNextActionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request); 
        ArgumentNullException.ThrowIfNull(request.CreateNextActionDto);

        BaseCommandResponse response = new();

        CreateNextActionsDtoValidator validator = new();
        ValidationResult? validationResult =
            await validator.ValidateAsync(request.CreateNextActionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(item => item.ErrorMessage).ToList();
        }
        else
        {
            NextAction? nextAction = await nextActionRepository.Add(request.CreateNextActionDto.ToNextAction());

            response.Success = true;
            response.Message = "Creation successful";
            response.Id = nextAction.Id;
        }

        return response;
    }
}
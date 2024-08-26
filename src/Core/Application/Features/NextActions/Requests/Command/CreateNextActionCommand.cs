namespace Numployable.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.NextActions;
using Responses;

public class CreateNextActionCommand : IRequest<BaseCommandResponse>
{
    public CreateNextActionDto? CreateNextActionDto { get; set; }
}
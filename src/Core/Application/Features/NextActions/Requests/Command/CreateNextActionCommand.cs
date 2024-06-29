namespace Numployable.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

public class CreateNextActionCommand : IRequest<BaseCommandResponse>
{
    public CreateNextActionDto? CreateNextActionDto { get; set; }
}
using Numployable.Domain;

namespace Numployable.Application.DTOs.NextActions;

public class CreateNextActionDto : BaseDto
{
    public required NextActionType NextActionType { get; init; }

    public required string ActionNote { get; init; }

    public DateTime ActionDate { get; init; }
}
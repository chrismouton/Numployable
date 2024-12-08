using Numployable.Application.DTOs.NextActions;
using Numployable.Domain;

namespace Numployable.Application.Mappings;

public static class NextActionMappings
{
    public static NextAction ToNextAction(this CreateNextActionDto from)
    {
        NextAction to = new()
        {
            Id = from.Id,
            ActionDate = from.ActionDate,
            ActionNote = from.ActionNote,
            NextActionType = from.NextActionType,
            NextActionTypeId = from.NextActionType.Id
        };

        return to;
    }

    public static NextAction ToNextAction(this UpdateNextActionDto from)
    {
        NextAction to = new()
        {
            ActionDate = from.ActionDate,
            ActionNote = from.ActionNote,
            NextActionType = from.NextActionType,
            NextActionTypeId = from.NextActionType.Id
        };

        return to;
    }

    public static NextActionDto ToNextAction(this NextAction from)
    {
        NextActionDto to = new()
        {
            Id = from.Id,
            ActionDate = from.ActionDate,
            ActionNote = from.ActionNote,
            NextActionType = from.NextActionType
        };

        return to;
    }
}
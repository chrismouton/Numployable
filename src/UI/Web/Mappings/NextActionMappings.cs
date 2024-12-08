using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Mappings;

public static class NextActionMappings
{
  public static CreateNextActionDto ToNextAction(this CreateNextActionViewModel from, IMapper mapper)
  {
    CreateNextActionDto to = new()
    {
      ActionDate = from.ActionDate,
      ActionNote = from.ActionNote,
      NextActionType = mapper.Map<NextActionType>(from.NextActionType)
    };

    return to;
  }

  public static NextActionViewModel ToNextAction(this NextActionDto from, IMapper mapper)
  {
    NextActionViewModel to = new()
    {
      ActionDate = DateTimeOffsetToDateTime(from.ActionDate.Value),
      ActionNote = from.ActionNote,
      NextActionType = mapper.Map<ReferenceDataViewModel>(from.NextActionType)
    };

    return to;
  }

  public static UpdateNextActionDto ToNextAction(this NextActionViewModel from, IMapper mapper)
  {
    UpdateNextActionDto to = new()
    {
      ActionDate = from.ActionDate,
      ActionNote = from.ActionNote,
      NextActionType = mapper.Map<NextActionType>(from.NextActionType)
    };

    return to;
  }

  private static DateTime DateTimeOffsetToDateTime(DateTimeOffset source)
  {
    string? dateTimeString = source.ToString();
    return DateTimeOffset.Parse(dateTimeString).UtcDateTime;
  }
}

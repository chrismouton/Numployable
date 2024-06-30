namespace Numployable;

using System.ComponentModel;

public enum NextActionType
{
    [Description("Suggest time slots")]
    SuggestTimeslots = 1,
    [Description("Initial call")]
    InitialCall = 2,
    [Description("Interview")]
    Interview = 3
}
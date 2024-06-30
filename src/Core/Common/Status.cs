namespace Numployable;

using System.ComponentModel;

public enum Status
{
    [Description("Active")]
    Active = 1,
    [Description("Expired")]
    Expired = 2,
    [Description("Closed")]
    Closed = 3
}
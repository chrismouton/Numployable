namespace Numployable;

using System.ComponentModel;

public enum Commute
{
    [Description("On-site")]
    OnSite = 1,
    [Description("Remote")]
    Remote = 2,
    [Description("Hybrid")]
    Hybrid = 3
}
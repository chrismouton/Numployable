namespace Numployable;

using System.ComponentModel;

public enum RoleType
{
    [Description("Permanent")]
    Permanent = 1,
    [Description("Contract")]
    Contract = 2,
    [Description("Part time")]
    PartTime = 3,
    [Description("Fixed-term contract")]
    FixedTermContract = 4,
    Volunteering = 5,
    [Description("Temporary Full-time")]
    TemporaryFullTime = 6
}
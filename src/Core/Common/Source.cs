namespace Numployable;

using System.ComponentModel;

public enum Source
{
    [Description("Job board")]
    JobBoard = 1,
    [Description("Networking")]
    Networking = 2,
    [Description("Recruiter contact")]
    RecruiterContact = 3,
    [Description("Recruiting site")]
    RecruitingSite = 4
}
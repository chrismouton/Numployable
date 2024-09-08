namespace Numployable;

using System.ComponentModel;

public enum ProcessStatus
{
    [Description("Applied")]
    Applied = 1,
    [Description("Interviewing")]
    Interviewing = 2,
    [Description("Waiting response")]
    WaitingResponse = 3,
    [Description("Offer received")]
    OfferReceived = 4,
    [Description("Hired")]
    Hired = 5,
    [Description("Rejected")]
    Rejected = 6,
    [Description("Retracted")]
    Retracted = 7
}
namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("JobApplicationId", Name = "NextAction_JobApplication_FK")]
[Index("NextActionTypeId", Name = "NextAction_NextActionType_FK")]
public partial class NextAction
{
}

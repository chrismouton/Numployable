namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("CommuteId", Name = "JobApplication_Commute_FK")]
[Index("ProcessStatusId", Name = "JobApplication_ProcessStatus_FK")]
[Index("RoleTypeId", Name = "JobApplication_RoleType_FK")]
[Index("SourceId", Name = "JobApplication_Source_FK")]
[Index("StatusId", Name = "JobApplication_Status_FK")]
public partial class JobApplication : Domain.JobApplication
{
}

namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "ApplicationProcessStatus_UNIQUE", IsUnique = true)]
public partial class ProcessStatus : Domain.ProcessStatus
{
}

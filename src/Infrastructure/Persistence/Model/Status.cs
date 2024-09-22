namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "ApplicationStatus_UNIQUE", IsUnique = true)]
public partial class Status : Domain.Status
{
}

namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "NextActionType_UNIQUE", IsUnique = true)]
public partial class NextActionType : Domain.NextActionType
{
}

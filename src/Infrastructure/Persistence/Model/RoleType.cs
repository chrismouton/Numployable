namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "RoleType_UNIQUE", IsUnique = true)]
public partial class RoleType : Domain.RoleType
{
}

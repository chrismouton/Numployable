namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "Commute_UNIQUE", IsUnique = true)]
public partial class Commute : Domain.Commute
{
}

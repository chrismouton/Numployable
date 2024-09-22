namespace Numployable.Persistence.Model;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "Source_UNIQUE", IsUnique = true)]
public partial class Source : Domain.Source
{
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public abstract class ReferenceDataBase : BaseDomainEntity
{
    [StringLength(100)]
    public string Description { get; set; } = null!;
}
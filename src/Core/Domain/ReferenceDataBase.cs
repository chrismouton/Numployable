using System.ComponentModel.DataAnnotations;

namespace Numployable.Domain;

public abstract class ReferenceDataBase : BaseDomainEntity
{
    [StringLength(100)] public string Description { get; set; } = null!;
}
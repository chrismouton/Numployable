using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public abstract class BaseDomainEntity
{
    [Key] [Column(TypeName = "int")] public int Id { get; set; }
}
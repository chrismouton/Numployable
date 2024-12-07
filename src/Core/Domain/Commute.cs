using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class Commute : ReferenceDataBase
{
    [InverseProperty("Commute")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}
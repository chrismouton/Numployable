namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Commute : ReferenceDataBase
{
    [InverseProperty("Commute")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}
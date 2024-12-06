namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Source : ReferenceDataBase
{
    [InverseProperty("Source")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
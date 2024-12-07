using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class Source : ReferenceDataBase
{
    [InverseProperty("Source")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
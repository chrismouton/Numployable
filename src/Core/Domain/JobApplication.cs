using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class JobApplication : BaseDomainEntity
{
    [StringLength(255)]
    public string RoleName { get; set; } = null!;

    [StringLength(255)]
    public string? CompanyName { get; set; } = null!;

    public int RoleTypeId { get; set; }

    public int StatusId { get; set; }

    public int ProcessStatusId { get; set; }

    public int SourceId { get; set; }

    [StringLength(255)]
    public string? AdvertisedSalary { get; set; }

    [StringLength(1024)]
    public string? Url { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    public int CommuteId { get; set; }

    [Column(TypeName = "date")]
    public DateTime ApplicationDate { get; set; }

    [StringLength(1024)]
    public string? Note { get; set; }

    public virtual Commute? Commute { get; set; } = null!;

    public virtual ProcessStatus ProcessStatus { get; set; } = null!;

    public virtual RoleType RoleType { get; set; } = null!;

    public virtual Source Source { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<NextAction> NextAction { get; set; } = [];}

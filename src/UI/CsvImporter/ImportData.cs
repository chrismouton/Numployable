namespace Numployable.CsvImporter;

public class ImportData
{
    public required int Id {get;set;}

    public required string RoleName {get; set;}

    public required string Company { get; set;}

    public string? ApplicationUrl { get; set; }

    public required string Status { get; set; }

    public string? AdvertisedSalary { get; set; }

    public required string RoleType { get; set; }

    public string? Location { get; set; }

    public string? Commute { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? NextAction {get; set;}

    public string? ConfidenceLevel { get; set; }
}
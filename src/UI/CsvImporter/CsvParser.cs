using System.Globalization;
using CsvHelper;
using Numployable.APIClient.Client;

namespace Numployable.CsvImporter;

internal class CsvParser(string filePath, string Url)
{
    public void Parse()
    {
        IEnumerable<ImportData> records = LoadRecords();

        foreach (ImportData record in records)
        {
            CreateJobApplicationDto jobApplication = new();

            jobApplication.RoleType = null;
            jobApplication.RoleName = record.RoleName;
            jobApplication.CompanyName = record.Company;
            jobApplication.ApplicationDate = record.ApplicationDate;
            jobApplication.Status = null;
            jobApplication.AdvertisedSalary = record.AdvertisedSalary;
            jobApplication.Location = record.Location;
            jobApplication.Commute = string.IsNullOrEmpty(record.Commute) ? null : GetCommute(record.Commute);
            jobApplication.Notes = record.Notes;

            if (record.NextAction is not null)
            {
                CreateNextActionDto nextAction = new()
                {
                    ActionDate = record.NextAction
                };
            }
        }
    }

    private RoleType GetRoleType(string roleType)
    {
        switch (roleType)
        {
            case "Permanent":
            case "Part Time":
            case "Contract":
            case "Fixed-Term Contract":
            case "Volunteering":
            case "Temporary Full-time":
                //return client.GetRoleTypeByDescription(roleType);
                break;
        }

        return null;
    }

    private Status GetStatus(string status, ref ProcessStatus processStatus)
    {
        switch (status)
        {
            case "Applied":
            case "Networking":
            case "Initial Call":
            case "Waiting Response":
            case "Interviewing":
            case "Offer Received":
            case "Hired":
            case "Rejected":
            case "Expired":
            case "Recruiter Contacted":
            case "Application Retracted":
                break;
        }

        return null;
    }

    private Commute GetCommute(string commute)
    {
        switch (commute)
        {
            case "Onsite":
            case "Hybrid":
            case "Remote":
                break;
        }

        return null;
    }

    private IEnumerable<ImportData> LoadRecords()
    {
        using StreamReader reader = new(filePath);
        using CsvReader csvReader = new(reader, CultureInfo.InvariantCulture);

        return csvReader.GetRecords<ImportData>();
    }
}
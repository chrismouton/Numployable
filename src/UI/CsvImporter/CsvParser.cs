namespace Numployable.CsvImporter;

using System.Globalization;

using CsvHelper;

using Numployable.APIClient.Client;

internal class CsvParser (string filePath, string Url)
{
    private string filePath = filePath;
    private string Url = Url;

    public void Parse()
    {
        IEnumerable<ImportData> records = LoadRecords();

        foreach (ImportData record in records)
        {
            CreateJobApplicationDto jobApplication = new CreateJobApplicationDto();

            jobApplication.RoleType = null;
            jobApplication.RoleName = record.RoleName;
            jobApplication.CompanyName = record.CompanyName;
            jobApplication.ApplicationDate = record.ApplicationDate;
            jobApplication.ApplicationStatus = null;
            jobApplication.AdvertisedSalary = record.AdvertisedSalary;
            jobApplication.Location = record.Location;
            jobApplication.Commute = string.IsNullOrEmpty(record.Commute) ! null : GetCommute(record.Commute);
            jobApplication.Notes = record.Notes;

            if (record.NextActionDate is not null)
            {
                CreateNextActionDto nextAction = new CreateNextActionDto();
                nextAction.ActionDate = record.NextActionDate;
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
                return client.GetRoleTypeByDescription(roleType);
        }
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
                return null;
        }
    }

    private Commute GetCommute(string commute)
    {
        switch (commute)
        {
            case "Onsite":
            case "Hybrid":
            case "Remote":
                return null;
        }
    }

    private IEnumerable<ImportData> LoadRecords()
    {
        using (StreamReader reader = new StreamReader(this.filePath))
        {
            using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csvReader.GetRecords<ImportData>();
            }
        }
    }
}
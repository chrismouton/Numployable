using System.Globalization;
using CsvHelper;
using Numployable.APIClient.Client;

namespace Numployable.CsvImporter;

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

    }

    private IEnumerable<ImportData> LoadRecords()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csvReader.GetRecords<ImportData>();
            }
        }
    }
}
using System.Globalization;
using CsvHelper;
using Numployable.APIClient.Client;

namespace Numployable.CsvImporter;

internal class CsvParser(string filePath, IClient client)
{
    public void Parse()
    {
        IEnumerable<ImportData> records = LoadRecords();
        List<ImportData> failedRecords = new List<ImportData>();

        Parallel.ForEach(records, async record =>
        {
            try
            {
                CreateJobApplicationDto jobApplication = new();

                jobApplication.RoleType = (await GetRoleType(record.RoleType)).ToRoleType();
                jobApplication.RoleName = record.RoleName;
                jobApplication.CompanyName = record.Company;
                jobApplication.ApplicationDate = record.ApplicationDate;

                ProcessStatus processStatus = (await GetProcessStatus(record.Status)).ToProcessStatus();
                Source source = (await GetSource(record.Status)).ToSource();
                jobApplication.Status = (await GetStatus(record.Status)).ToStatus();

                jobApplication.AdvertisedSalary = record.AdvertisedSalary;
                jobApplication.Location = record.Location;
                jobApplication.Commute = string.IsNullOrEmpty(record.Commute) ? null : (await GetCommute(record.Commute)).ToCommute();
                jobApplication.Notes = record.Notes;

                if (record.NextAction is not null)
                {
                    CreateNextActionDto nextAction = new()
                    {
                        ActionDate = record.NextAction
                    };
                }

                await client.JobApplicationPOSTAsync(jobApplication);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                failedRecords.Add(record);
            } // try/catch            
        });
    }

    private async Task<RoleTypeDto> GetRoleType(string roleType)
    {
        switch (roleType)
        {
            case "Permanent":
            case "Contract":
            case "Part Time":
            case "Volunteering":
                return await client.RoletypeAsync(roleType);
            case "Fixed-Term Contract":
                return await client.RoletypeAsync("Fixed-term contract");
            case "Temporary Full-time":
                return await client.RoletypeAsync("Temporary full-time");
                break;
        }

        return await Task.FromException<RoleTypeDto>(new ApplicationException("Unrecognized Role Type"));
    }

    private async Task<StatusDto> GetStatus(string status)
    {
        StatusDto convertedStatus = await client.StatusAsync("Active");

        switch (status)
        {
            case "Applied":
                break;
            case "Networking":
                break;
            case "Initial Call":
                break;
            case "Waiting Response":
                break;
            case "Interviewing":
                break;
            case "Offer Received":
                break;
            case "Hired":
                convertedStatus = await client.StatusAsync("Closed");
                break;
            case "Rejected":
                convertedStatus = await client.StatusAsync("Closed");
                break;
            case "Expired":
                convertedStatus = await client.StatusAsync("Expired");
                break;
            case "Recruiter Contacted":
                break;
            case "Application Retracted":
                convertedStatus = await client.StatusAsync("Closed");
                break;
        }

        return convertedStatus;
    }

    private async Task<ProcessStatusDto> GetProcessStatus(string status)
    {
        ProcessStatusDto processStatus = await client.ProcessstatusAsync("Applied");

        switch (status)
        {
            case "Applied":
                break;
            case "Networking":
                break;
            case "Initial Call":
                processStatus = await client.ProcessstatusAsync("Interviewing");
                break;
            case "Waiting Response":
                processStatus = await client.ProcessstatusAsync("Waiting response");
                break;
            case "Interviewing":
                processStatus = await client.ProcessstatusAsync("Interviewing");
                break;
            case "Offer Received":
                processStatus = await client.ProcessstatusAsync("Offer received");
                break;
            case "Hired":
                processStatus = await client.ProcessstatusAsync("Hired");
                break;
            case "Rejected":
                processStatus = await client.ProcessstatusAsync("Rejected");
                break;
            case "Expired":
                break;
            case "Recruiter Contacted":
                break;
            case "Application Retracted":
                processStatus = await client.ProcessstatusAsync("Retracted");
                break;
        }

        return processStatus;
    }

    private async Task<SourceDto> GetSource(string status)
    {
        SourceDto source = await client.SourceAsync("Job board");

        switch (status)
        {
            case "Applied":
                break;
            case "Networking":
                source = await client.SourceAsync("Networking");
                break;
            case "Initial Call":
                break;
            case "Waiting Response":
                break;
            case "Interviewing":
                break;
            case "Offer Received":
                break;
            case "Hired":
                break;
            case "Rejected":
                break;
            case "Expired":
                break;
            case "Recruiter Contacted":
                source = await client.SourceAsync("Recruiter contact");
                break;
            case "Application Retracted":
                break;
        }

        return source;
    }

    private async Task<CommuteDto> GetCommute(string commute)
    {
        switch (commute)
        {
            case "Onsite":
                return await client.CommuteAsync("On-site");
            case "Hybrid":
            case "Remote":
                return await client.CommuteAsync(commute);
        }

        return await Task.FromException<CommuteDto>(new ApplicationException("Unrecognized Commute Type"));
    }

    private IEnumerable<ImportData> LoadRecords()
    {
        using StreamReader reader = new(filePath);
        using CsvReader csvReader = new(reader, CultureInfo.InvariantCulture);

        return csvReader.GetRecords<ImportData>();
    }

    private void SaveRecords(IEnumerable<ImportData> records, string filePath)
    {
        using StreamWriter writer = new(filePath);
        using CsvWriter csvWriter = new(writer, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(records);
    }
}
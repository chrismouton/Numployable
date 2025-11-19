using Numployable.APIClient.Client;

namespace Numployable.CsvImporter;

public static class ReferenceDataMapping
{
    public static Commute ToCommute(this CommuteDto from)
    {
        return new Commute()
            {
                Id = from.Id,
                Description = from.Description
            };
    }

    public static RoleType ToRoleType(this RoleTypeDto from)
    {
        return new RoleType()
            {
                Id = from.Id,
                Description = from.Description
            };
    }

    public static ProcessStatus ToProcessStatus(this ProcessStatusDto from)
    {
        return new ProcessStatus()
            {
                Id = from.Id,
                Description = from.Description
            };
    }

    public static Source ToSource(this SourceDto from)
    {
        return new Source()
            {
                Id = from.Id,
                Description = from.Description
            };
    }

    public static Status ToStatus(this StatusDto from)
    {
        return new Status()
            {
                Id = from.Id,
                Description = from.Description
            };
    }
}
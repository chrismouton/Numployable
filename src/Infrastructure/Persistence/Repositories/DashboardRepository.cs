namespace Numployable.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class DashboardRepository(NumployableDbContext dbContext, IMapper mapper)
        : IDashboardRepository
{
    public async Task<Dashboard> Get()
    {
        Dashboard dashboard = new Dashboard();

        dashboard.TotalCount = 0;

        var result = dbContext.Database.SqlQuery<int>($"SELECT COUNT(\"Id\") FROM public.\"JobApplication\"").ToList();
        if (result.Count() > 0)
            dashboard.TotalCount = result[0];

        return dashboard;
    }
}

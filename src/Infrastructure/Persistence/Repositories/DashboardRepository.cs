using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class DashboardRepository(NumployableDbContext dbContext, IMapper mapper)
    : IDashboardRepository
{
    public Task<Dashboard> Get()
    {
        Dashboard? dashboard = new()
        {
            TotalCount = 0
        };

        List<int>? result = dbContext.Database.SqlQuery<int>($"SELECT COUNT(\"Id\") FROM public.\"JobApplication\"")
            .ToList();
        if (result.Count > 0)
            dashboard.TotalCount = result[0];

        return Task.FromResult(dashboard);
    }
}
namespace Numployable.Persistence.Repositories;

using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class NextActionRepository(NumployableDbContext dbContext)
    : GenericRepository<NextAction>(dbContext), INextActionRepository
{
}
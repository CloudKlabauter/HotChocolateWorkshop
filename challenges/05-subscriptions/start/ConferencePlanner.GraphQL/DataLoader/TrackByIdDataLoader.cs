using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.DataLoader;

public class TrackByIdDataLoader : BatchDataLoader<int, Track>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public TrackByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory ??
            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Track>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext =
            _dbContextFactory.CreateDbContext();

        return await dbContext.Tracks
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
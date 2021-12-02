using Microsoft.EntityFrameworkCore;
using Library.GraphQL.Data;

namespace Library.GraphQL.DataLoader;

public class AuthorByIdDataLoader : BatchDataLoader<int, Author>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public AuthorByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory ??
            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Author>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext =
            _dbContextFactory.CreateDbContext();

        return await dbContext.Authors
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
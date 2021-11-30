using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Types;

namespace ConferencePlanner.GraphQL.Sessions;

[ExtendObjectType("Query")]
public class SessionQueries
{
    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging(typeof(NonNullType<SessionType>))]
    [UseFiltering(typeof(SessionFilterInputType))]
    [UseSorting]
    public IQueryable<Session> GetSessions(
        [ScopedService] ApplicationDbContext context) =>
        context.Sessions;

    public Task<Session> GetSessionByIdAsync(
        [ID(nameof(Session))] int id,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        sessionById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
        [ID(nameof(Session))] int[] ids,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        await sessionById.LoadAsync(ids, cancellationToken);
}
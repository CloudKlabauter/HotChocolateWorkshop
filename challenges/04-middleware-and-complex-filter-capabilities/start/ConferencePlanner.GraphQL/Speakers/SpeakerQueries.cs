using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.DataLoader;

namespace ConferencePlanner.GraphQL.Speakers;

[ExtendObjectType("Query")]
public class SpeakerQueries
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
        context.Speakers.ToListAsync();

    public Task<Speaker> GetSpeakerByIdAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
        [ID(nameof(Speaker))] int[] ids,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        await dataLoader.LoadAsync(ids, cancellationToken);
}

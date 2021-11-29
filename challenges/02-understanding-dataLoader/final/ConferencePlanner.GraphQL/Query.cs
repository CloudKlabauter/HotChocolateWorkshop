using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.DataLoader;

namespace ConferencePlanner.GraphQL;

public class Query
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
        context.Speakers.ToListAsync();

    public Task<Speaker> GetSpeakerAsync(int id, SpeakerByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}

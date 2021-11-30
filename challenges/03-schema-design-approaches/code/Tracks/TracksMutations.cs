using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Tracks;

[ExtendObjectType("Mutation")]
public class TrackMutations
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<AddTrackPayload> AddTrackAsync(
        AddTrackInput input,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var track = new Track { Name = input.Name };
        context.Tracks.Add(track);

        await context.SaveChangesAsync(cancellationToken);

        return new AddTrackPayload(track);
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<RenameTrackPayload> RenameTrackAsync(
      RenameTrackInput input,
      [ScopedService] ApplicationDbContext context,
      CancellationToken cancellationToken)
    {
        Track? track = await context.Tracks.FindAsync(input.Id);

        if (track is null)
        {
            return new RenameTrackPayload(
                new UserError("Track not found.", "TRACK_NOT_FOUND"));
        }

        track.Name = input.Name;

        await context.SaveChangesAsync(cancellationToken);

        return new RenameTrackPayload(track);
    }
}
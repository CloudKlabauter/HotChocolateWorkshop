using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;

namespace ConferencePlanner.GraphQL.Attendees;

[ExtendObjectType("Query")]
public class AttendeeQueries
{
    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    public IQueryable<Attendee> GetAttendees(
        [ScopedService] ApplicationDbContext context) =>
        context.Attendees;

    public Task<Attendee> GetAttendeeByIdAsync(
        [ID(nameof(Attendee))] int id,
        AttendeeByIdDataLoader attendeeById,
        CancellationToken cancellationToken) =>
        attendeeById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Attendee>> GetAttendeesByIdAsync(
        [ID(nameof(Attendee))] int[] ids,
        AttendeeByIdDataLoader attendeeById,
        CancellationToken cancellationToken) =>
        await attendeeById.LoadAsync(ids, cancellationToken);
}
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace ConferencePlanner.GraphQL.Attendees;

[ExtendObjectType("Subscription")]
public class AttendeeSubscriptions
{
    [Subscribe(With = nameof(SubscribeToOnAttendeeCheckedInAsync))]
    public SessionAttendeeCheckIn OnAttendeeCheckedIn(
        [ID(nameof(Session))] int sessionId,
        [EventMessage] int attendeeId,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        new SessionAttendeeCheckIn(attendeeId, sessionId);

    public async ValueTask<ISourceStream<int>> SubscribeToOnAttendeeCheckedInAsync(
        int sessionId,
        [Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken) =>
        await eventReceiver.SubscribeAsync<string, int>(
            "OnAttendeeCheckedIn_" + sessionId, cancellationToken);
}

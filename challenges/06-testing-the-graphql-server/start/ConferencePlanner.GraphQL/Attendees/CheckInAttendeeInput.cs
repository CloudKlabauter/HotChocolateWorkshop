using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Attendees;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
        int SessionId,
    [ID(nameof(Attendee))]
        int AttendeeId);
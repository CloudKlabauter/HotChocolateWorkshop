using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Sessions;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);
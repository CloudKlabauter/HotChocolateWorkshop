using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Sessions;

public class AddSessionInput
{
    [ID(nameof(Speaker))]
    public IReadOnlyList<int> SpeakerIds { get; set; } = default!;

    public string Title { get; set; } = default!;

    public string? Abstract { get; set; }
}
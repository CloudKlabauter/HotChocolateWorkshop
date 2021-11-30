using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Tracks;

public class RenameTrackInput
{
    [ID(nameof(Track))]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
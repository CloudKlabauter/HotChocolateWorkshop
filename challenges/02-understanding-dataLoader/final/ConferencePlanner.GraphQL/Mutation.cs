using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL;

public class Mutation
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}

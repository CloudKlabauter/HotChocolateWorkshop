using Microsoft.Extensions.DependencyInjection;
using GraphQLConsole.GraphQL;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddConferenceClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://workshop.chillicream.com/graphql")   );

IServiceProvider services = serviceCollection.BuildServiceProvider(         );

IConferenceClient client = services.GetRequiredService<IConferenceClient>();

var getSessionResult = await client.GetSessions.ExecuteAsync();
getSessionResult.EnsureNoErrors();

foreach (var session in getSessionResult.Data!.Sessions!.Nodes!)
{
    Console.WriteLine(session.Title);
}

var addSpeakerResult = await client.AddSpeaker.ExecuteAsync("Torsten Weber", null, null);
addSpeakerResult.EnsureNoErrors();

Console.WriteLine($"Id of new speaker: {addSpeakerResult.Data!.AddSpeaker.Speaker!.Id}");

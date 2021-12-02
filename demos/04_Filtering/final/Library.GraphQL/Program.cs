using Library.GraphQL.Data;
using Library.GraphQL;
using Microsoft.EntityFrameworkCore;
using Library.GraphQL.DataLoader;
using Library.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=library.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<AuthorType>()
    .AddType<BookType>()
    .AddGlobalObjectIdentification()
    .AddFiltering()
    .AddSorting()
    .AddDataLoader<BookByIdDataLoader>()
    .AddDataLoader<AuthorByIdDataLoader>();

var app = builder.Build();

app.MapGraphQL();

app.Run();

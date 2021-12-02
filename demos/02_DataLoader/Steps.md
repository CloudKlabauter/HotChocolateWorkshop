# Demo 2: DataLoaders

`builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=library.db"));`

```console
dotnet add Library.GraphQL package HotChocolate.Data.EntityFramework --version 12.3.2
```

Service => ScopedService

```graphql
query GetBookParallel {
  a: books {
    id
    title
  }
  b: books {
    id
    title
  }
  c: books {
    id
    title
  }
}
```

```console
dotnet build Library.GraphQL
dotnet ef migrations add Refactoring --project Library.GraphQL
dotnet ef database update --project Library.GraphQL

mkdir Library.GraphQL/DataLoader
mkdir Library.GraphQL/Types

```

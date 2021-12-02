# Demo 1: Create a Hot Chocolate Server

```bash
dotnet new sln -n Library
dotnet new web -n Library.GraphQL
dotnet sln add Library.GraphQL

mkdir Library.GraphQL/Data

dotnet add Library.GraphQL package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.0
dotnet add Library.GraphQL package Microsoft.EntityFrameworkCore.Tools --version 6.0.0
dotnet add Library.GraphQL package HotChocolate.AspNetCore --version 12.3.2

dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.0 --local

dotnet build Library.GraphQL
dotnet ef migrations add Initial --project Library.GraphQL
dotnet ef database update --project Library.GraphQL

dotnet run --project Library.GraphQL
```

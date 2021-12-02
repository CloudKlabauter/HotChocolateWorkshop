using Library.GraphQL.Data;
using Library.GraphQL.DataLoader;

namespace Library.GraphQL;

public class Query
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public IQueryable<Author> GetAuthors([ScopedService] ApplicationDbContext context) =>
        context.Authors;

    [UseDbContext(typeof(ApplicationDbContext))]
    public IQueryable<Book> GetBooks([ScopedService] ApplicationDbContext context) =>
            context.Books;

    public Task<Book> GetBookAsync(int id, BookByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}
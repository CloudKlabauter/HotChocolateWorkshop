using Library.GraphQL.Data;

namespace Library.GraphQL;

public class Query
{
    public IQueryable<Author> GetAuthors([Service] ApplicationDbContext context) =>
        context.Authors;

    public IQueryable<Book> GetBooks([Service] ApplicationDbContext context) =>
        context.Books;
}
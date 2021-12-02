using Library.GraphQL.Data;

namespace Library.GraphQL;

public class Mutation
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<AddBookPayload> AddBookAsync(
        AddBookInput input,
        [ScopedService] ApplicationDbContext context)
    {
        var book = new Book
        {
            Title = input.Title,
            ISBN = input.ISBN,
            Description = input.Description,
            AuthorId = input.AuthorId
        };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return new AddBookPayload(book);
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<AddAuthorPayload> AddAuthorAsync(
       AddAuthorInput input,
       [ScopedService] ApplicationDbContext context)
    {
        var author = new Author
        {
            Name = input.Name
        };

        context.Authors.Add(author);
        await context.SaveChangesAsync();

        return new AddAuthorPayload(author);
    }
}
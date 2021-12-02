using Library.GraphQL.Data;

namespace Library.GraphQL;

public class Mutation
{
    public async Task<AddBookPayload> AddBookAsync(
        AddBookInput input,
        [Service] ApplicationDbContext context)
    {
        var book = new Book
        {
            Title = input.Title,
            ISBN = input.ISBN,
            Description = input.Description
        };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return new AddBookPayload(book);
    }
}
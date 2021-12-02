using Microsoft.EntityFrameworkCore;
using Library.GraphQL.Data;
using Library.GraphQL.DataLoader;

namespace Library.GraphQL.Types;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor
            .Field(t => t.Books)
            .ResolveWith<AuthorResolvers>(t => t.GetBooksAsync(default!, default!, default!, default))
            .UseDbContext<ApplicationDbContext>()
            .Name("books");
    }

    private class AuthorResolvers
    {
        public async Task<IEnumerable<Book>> GetBooksAsync(
            [Parent] Author author,
            [ScopedService] ApplicationDbContext dbContext,
            BookByIdDataLoader bookById,
            CancellationToken cancellationToken)
        {
            int[] bookIds = await dbContext.Books
                .Where(s => s.AuthorId == author.Id)
                .Select(s => s.Id)
                .ToArrayAsync();

            return await bookById.LoadAsync(bookIds, cancellationToken);
        }
    }
}
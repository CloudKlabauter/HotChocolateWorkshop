using Library.GraphQL.Data;
using Library.GraphQL.DataLoader;

namespace Library.GraphQL.Types;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<BookByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.Author)
            .ResolveWith<BookResolvers>(t => t.GetAuthorAsync(default!, default!, default!, default))
            .UseDbContext<ApplicationDbContext>()
            .Name("author");
    }

    private class BookResolvers
    {
        public async Task<IEnumerable<Author>?> GetAuthorAsync(
            [Parent] Book book,
            [ScopedService] ApplicationDbContext dbContext,
            AuthorByIdDataLoader authorById,
            CancellationToken cancellationToken)
        {

            if (book.AuthorId == null)
                return null;

            int[] authorIds = new int[] { book.AuthorId.Value };

            return await authorById.LoadAsync(authorIds, cancellationToken);
        }
    }
}
using Library.GraphQL.Data;

namespace Library.GraphQL;

public class AddAuthorPayload
{
    public AddAuthorPayload(Author author)
    {
        Author = author;
    }

    public Author Author { get; }
}
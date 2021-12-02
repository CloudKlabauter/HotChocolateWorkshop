using Library.GraphQL.Data;

namespace Library.GraphQL;

public class AddBookPayload
{
    public AddBookPayload(Book book)
    {
        Book = book;
    }

    public Book Book { get; }
}
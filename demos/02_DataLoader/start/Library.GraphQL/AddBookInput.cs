namespace Library.GraphQL;

public class AddBookInput
{
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string? Description { get; set; }
}
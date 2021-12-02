using System.ComponentModel.DataAnnotations;

namespace Library.GraphQL.Data;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = default!;

    public ICollection<Book> Books { get; set; } =
           new List<Book>();
}
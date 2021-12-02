using System.ComponentModel.DataAnnotations;

namespace Library.GraphQL.Data;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = default!;

    [Required]
    [StringLength(13)]
    public string ISBN { get; set; } = default!;

    [StringLength(2000)]
    public string? Description { get; set; }
}
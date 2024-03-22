using System.Collections.ObjectModel;

namespace Book.API;

public class Book : Entity
{
    // EF Constructor
    private Book()
    {

    }
    private Book(
        Guid id,
        string title,
        string isbn,
        int amountPages,
        GenreType genre,
        Guid publisherId,
        Author author) : base(id)
    {
        Title = title;
        ISBN = isbn;
        AmountPages = amountPages;
        GenreType = genre;
        PublisherId = publisherId;
        Author = author;
    }

    public string Title { get; private set; } = null!;
    public string ISBN { get; private set; } = null!;
    public int AmountPages { get; private set; }
    public GenreType GenreType { get; private set; }
    public Author Author { get; private set; } = null!;
    public Guid PublisherId { get; private set; }

    public static Book Create(
        string title, string isbn, int amountPages, GenreType genre, Guid publisherId, Author author)
        => new(new Guid(), title, isbn, amountPages, genre, publisherId, author);
}

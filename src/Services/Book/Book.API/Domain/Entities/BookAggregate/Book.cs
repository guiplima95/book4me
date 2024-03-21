namespace Book.API;

public class Book : Entity
{
    // EF Constructor
    private Book()
    {

    }
    private Book(Guid id, Title title, ISBN isbn, int amountPages, Guid publisherId, Guid authorId) : base(id)
    {
        Title = title;
        ISBN = isbn;
        AmountPages = amountPages;
        PublisherId = publisherId;
        AuthorId = authorId;
    }

    public Title Title { get; private set; }
    public ISBN ISBN { get; private set; }
    public int AmountPages { get; private set; }
    public Guid AuthorId { get; private set; }
    public Guid PublisherId { get; private set; }

    public static Book Create(Title title, ISBN isbn, int amountPages, Guid publisherId, Guid authorId)
        => new(new Guid(), title, isbn, amountPages, publisherId, authorId);
}

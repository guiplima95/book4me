using System.Collections.ObjectModel;

namespace Book.API;

public class Publisher : Entity
{
    // EF Core constructor
    private Publisher()
    {

    }

    private Publisher(Guid id, string name, DateTime bookPublished) : base(id)
    {
        Name = name;
        BookPublishedUtc = bookPublished;
    }

    public string Name { get; private set; } = null!;

    public DateTime BookPublishedUtc { get; private set; }

    public Collection<Book>? Books { get; set; }

    public static Publisher Create(string name, DateTime bookPublished) => new(Guid.NewGuid(), name, bookPublished);
}

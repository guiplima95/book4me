using System.Collections.ObjectModel;

namespace Book.API;

public class Publisher : Entity
{
    // EF Core constructor
    private Publisher()
    {

    }

    private Publisher(Guid id, Name name) : base(id) => Name = name;

    public Name Name { get; private set; }

    public Collection<Book>? Books { get; set; }

    public static Publisher Create(Name name) => new(Guid.NewGuid(), name);
}

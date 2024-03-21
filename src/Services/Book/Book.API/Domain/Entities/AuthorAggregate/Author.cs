namespace Book.API;

public class Author : Entity
{
    // EFCore Constructor
    private Author()
    {
    }
    private Author(Guid id, FirstName firstName, LastName lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public ICollection<Book>? Books { get; set; }

    public static Author Create(FirstName firstName, LastName lastName)
         => new(new Guid(), firstName, lastName);
}
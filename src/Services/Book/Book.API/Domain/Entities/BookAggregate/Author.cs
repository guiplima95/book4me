using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API;

[ComplexType]
public record Author(string FirstName, string LastName);
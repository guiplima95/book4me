using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.API;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder
            .HasKey(c => c.Id)
            .IsClustered(false)
            .HasName("PK_Book");

        builder
            .Property(b => b.Id)
            .ValueGeneratedNever()
            .HasDefaultValueSql("newsequentialid()")
            .IsRequired();

        builder
            .Property(b => b.ISBN)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder
            .Property(b => b.GenreType)
            .IsRequired()
            .HasDefaultValue(GenreType.None);

        builder
            .Property(b => b.AmountPages)
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(b => b.PublisherId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasOne<Publisher>()
            .WithMany(b => b.Books)
            .IsRequired()
            .HasForeignKey(p => p.PublisherId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Publisher_Book");

        builder
            .ComplexProperty(
                x => x.Author, a =>
                {
                    a.Property(x => x.FirstName)
                       .HasColumnName("AuthorFirstName")
                       .HasColumnType("nvarchar(50)")
                       .IsRequired();
                    a.Property(x => x.LastName)
                       .HasColumnName("AuthorLastName")
                       .HasColumnType("nvarchar(50)")
                       .IsRequired();
                });
    }
}
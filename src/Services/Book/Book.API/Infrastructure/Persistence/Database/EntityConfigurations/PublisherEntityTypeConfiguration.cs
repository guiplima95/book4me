using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.API;

public class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");

        builder
            .HasKey(c => c.Id)
            .IsClustered(false)
            .HasName("PK_Publisher");

        builder
            .Property(b => b.Id)
            .ValueGeneratedNever()
            .HasDefaultValueSql("newsequentialid()")
            .IsRequired();

        builder
            .Property(b => b.Name)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder
            .Property(b => b.BookPublishedUtc)
            .HasColumnType("datetime");
    }
}
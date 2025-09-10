using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace course_learning_tutorial.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(200);
	}
}

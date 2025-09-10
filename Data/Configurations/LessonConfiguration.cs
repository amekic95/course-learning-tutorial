using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace course_learning_tutorial.Data.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
	public void Configure(EntityTypeBuilder<Lesson> builder)
	{
		builder.Property(x => x.Title)
			.IsRequired()
			.HasMaxLength(200);

		builder.HasIndex(x => new { x.CourseId, x.Title }).IsUnique();
	}
}

using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace course_learning_tutorial.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		builder.ToTable("Courses");

		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(200);

		builder.HasIndex(x => new { x.AuthorId, x.Name }).IsUnique();

		builder.HasOne(x => x.Author)
			.WithMany(a => a.Courses)
			.HasForeignKey(x => x.AuthorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(x => x.Lessons)
			.WithOne(l => l.Course)
			.HasForeignKey(l => l.CourseId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}

using course_learning_tutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace course_learning_tutorial.Data.Configurations;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
	public void Configure(EntityTypeBuilder<CourseStudent> builder)
	{
		builder.HasKey(x => new { x.CourseId, x.StudentId });

		builder.HasOne(x => x.Course)
			.WithMany(c => c.CourseStudents)
			.HasForeignKey(x => x.CourseId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Student)
			.WithMany(s => s.CourseStudents)
			.HasForeignKey(x => x.StudentId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}

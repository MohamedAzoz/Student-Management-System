using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Management_System.Entities;

namespace Student_Management_System.Data.config
{
    public class EnrollmentConfiguratin : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e =>e.Id);
            builder.Property(c => c.Id).HasColumnType("VARCHAR")
            .HasMaxLength(14).ValueGeneratedNever();

            builder.Property(c => c.CourseId).HasColumnType("VARCHAR")
               .HasMaxLength(14).ValueGeneratedNever();

            builder.Property(s => s.StudentId).HasColumnType("VARCHAR")
                .HasMaxLength(14).ValueGeneratedNever();

            builder.ToTable("Enrollments");

            builder.HasData(
                new Enrollment {Id ="#7994", CourseId = "#1", StudentId = "12345678901234" },
                new Enrollment {Id ="#9451", CourseId = "#2", StudentId = "12345678901234" },
                new Enrollment {Id ="#2454", CourseId = "#3", StudentId = "12345678901234" },
                                
                new Enrollment {Id ="#1454", CourseId = "#4", StudentId = "23456789012345" },
                new Enrollment {Id ="#8541", CourseId = "#5", StudentId = "23456789012345" },
                new Enrollment {Id ="#1234", CourseId = "#6", StudentId = "23456789012345" },
                                                         
                new Enrollment {Id ="#1245", CourseId = "#7", StudentId = "34567890123456" },
                new Enrollment {Id ="#9884", CourseId = "#8", StudentId = "34567890123456" },
                new Enrollment {Id ="#7845", CourseId = "#9", StudentId = "34567890123456" }
              
            );
        }
    }
}

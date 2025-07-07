using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data.config
{
    public class CourseConfiguratin : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasMaxLength(14)
                .HasColumnType("VARCHAR")
                .ValueGeneratedNever();

            builder.Property(c => c.CourseCode).HasColumnType("VARCHAR")
                .HasMaxLength(14).ValueGeneratedNever();


            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(h=>h.Number_of_hours)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(s => s.Department)
                .IsRequired()
                .HasMaxLength(100);


            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            builder.ToTable("Courses");

            builder.HasData(
                new Course { Id ="#1",CourseCode = "En01", Department= "Computer Science", Name = "DataBase", Number_of_hours = 40 },
                new Course { Id ="#2",CourseCode = "En02", Department= "Computer Science", Name = "C#", Number_of_hours = 40 },
                new Course { Id ="#3",CourseCode = "En03", Department= "Computer Science", Name = "OOP", Number_of_hours = 40 },
                new Course { Id ="#4",CourseCode = "AR01", Department= "English Literature", Name = "Lisning", Number_of_hours = 45 },
                new Course { Id ="#5",CourseCode = "AR02", Department= "English Literature", Name = "Reading", Number_of_hours = 45 },
                new Course { Id ="#6",CourseCode = "AR03", Department= "English Literature", Name = "Writing", Number_of_hours = 50 },
                new Course { Id ="#7",CourseCode = "SC01", Department= "Physics", Name = "Physics", Number_of_hours = 50 },
                new Course { Id ="#8",CourseCode = "SC02", Department= "Physics", Name = "Mathematics", Number_of_hours = 50 },
                new Course { Id ="#9",CourseCode = "SC03", Department= "Physics", Name = "Chemistry", Number_of_hours = 50 }
            );
        }
    }
}
